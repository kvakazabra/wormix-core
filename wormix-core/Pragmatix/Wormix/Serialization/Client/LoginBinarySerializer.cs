using wormix_core.Extensions;
using wormix_core.Pragmatix.Flox.Serialization.Interfaces;
using wormix_core.Pragmatix.Wormix.Messages.Client;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Wormix.Serialization.Client;

public class LoginBinarySerializer : ICommandSerializer
{
    public uint GetCommandId()
    {
        return 1;
    }

    public void SerializeCommand(ISerializable command, Stream output)
    {
        //Not needed
    }

    public ISerializable DeserializeCommand(Stream input, ICommandHeader header)
    {
        Login msg = new();

        BinaryReader br = new BinaryReader(input);
        msg.Id = br.ReadUInt32Be();
        msg.ReferrerId = br.ReadUInt32Be();
        msg.AuthKey = br.ReadUTF8();
        msg.Version = ParseVersion((int)br.ReadUInt32Be());
        ushort n = br.ReadUInt16Be();
        for (int i = 0; i < n; i++)
            msg.Ids.Add(br.ReadUInt32Be());
        msg.SocialCode = br.ReadByte();
        n = br.ReadUInt16Be();
        for (int i = 0; i < n; i++)
            msg.Params.Add(br.ReadUTF8());

        return msg;
    }

    private static string ParseVersion(int version)
    {
        int b0 = (version >> 24) & 0xFF;
        int b1 = (version >> 16) & 0xFF;
        int b2 = (version >> 8) & 0xFF;
        int b3 = version & 0xFF;
        return $"{b0}.{b1}.{b2}.{b3}";
    }
}
