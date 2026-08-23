using System.Text;
using wormix_core.Controllers.Http.Account;
using wormix_core.Controllers.Http.Game;
using wormix_core.Controllers.Http.Info;
using wormix_core.Controllers.Static.Account;
using wormix_core.Controllers.Static.Service;
using wormix_core.Handlers;
using wormix_core.Handlers.Account;
using wormix_core.Handlers.Game;
using wormix_core.Handlers.Info;
using wormix_core.Handlers.Service;
using wormix_core.Pragmatix.Wormix.Serialization.Client;
using wormix_core.Server;

namespace wormix_core.Session;

public class AchievementsSession(TcpServer server) : TcpSession(server)
{

    protected override Dictionary<uint, GameMessageHandler> GetHandlers()
    {
        return new()
        {
            {16, new PingHandler(new PingBinarySerializer(), new PingController(), this) },

            {3001, new AchieveLoginHandler(new AchieveLoginBinarySerializer(), new AchieveLoginController(), this)},
        };
    }

    private static Stream ExtractPostBodyToStream(Stream dataStream)
    {
        var headerBytes = new List<byte>();
        int prevA = -1, prevB = -1, prevC = -1, prevD = -1; // sliding window for \r\n\r\n
        int b;

        while ((b = dataStream.ReadByte()) != -1)
        {
            headerBytes.Add((byte)b);

            prevA = prevB; prevB = prevC; prevC = prevD; prevD = b;
            if (prevA == '\r' && prevB == '\n' && prevC == '\r' && prevD == '\n')
                break; // found end of headers
        }

        string headerText = Encoding.ASCII.GetString(headerBytes.ToArray());
        string[] lines = headerText.Split(new[] { "\r\n" }, StringSplitOptions.None);

        // --- 2. Parse Content-Length from headers ---
        int contentLength = 0;
        foreach (string line in lines)
        {
            int colonIdx = line.IndexOf(':');
            if (colonIdx <= 0) continue;

            string name = line.Substring(0, colonIdx).Trim();
            string value = line.Substring(colonIdx + 1).Trim();

            if (string.Equals(name, "Content-Length", StringComparison.OrdinalIgnoreCase))
            {
                if (!int.TryParse(value, out contentLength))
                    throw new InvalidDataException($"Invalid Content-Length value: '{value}'");
            }
        }

        if (contentLength <= 0)
        {
            // No body expected / declared
            return new MemoryStream(Array.Empty<byte>());
        }

        // --- 3. Read exactly contentLength bytes for the body ---
        byte[] bodyBuffer = new byte[contentLength];
        int totalRead = 0;
        while (totalRead < contentLength)
        {
            int read = dataStream.Read(bodyBuffer, totalRead, contentLength - totalRead);
            if (read == 0)
                throw new EndOfStreamException("Stream ended before full body was received.");
            totalRead += read;
        }

        var bodyStream = new MemoryStream(bodyBuffer);
        bodyStream.Position = 0;
        return bodyStream;
    }

    protected override void OnMessage(Stream dataStream)
    {
        Stream parsedPostStream = ExtractPostBodyToStream(dataStream);
        ProcessMessage(parsedPostStream);
    }

    public override void SendMessage(byte[] message)
    {
        var sb = new StringBuilder();
        sb.Append("HTTP/1.1 200 OK\r\n");
        sb.Append("Content-Type: application/octet-stream\r\n");
        sb.Append($"Content-Length: {message.Length}\r\n");
        sb.Append("Connection: close\r\n");
        sb.Append("\r\n");

        byte[] head = Encoding.ASCII.GetBytes(sb.ToString());
        byte[] response = new byte[head.Length + message.Length];
        Buffer.BlockCopy(head, 0, response, 0, head.Length);
        Buffer.BlockCopy(message, 0, response, head.Length, message.Length);

        base.SendMessage(response); // raw socket send
    }
}