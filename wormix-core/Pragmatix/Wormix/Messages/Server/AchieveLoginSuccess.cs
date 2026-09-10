using wormix_core.Extensions;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Wormix.Messages.Server;

public struct AchieveLoginSuccess() : ISerializable
{
    public string SessionId = "";
    public uint LoginTime;
    public bool IsSecure;

    public uint GetSize()
    {
        return (uint)(
            // SessionId
            2 + System.Text.Encoding.UTF8.GetByteCount(SessionId) +
            // LoginTime
            4
        );
    }

    public void Serialize(Stream output)
    {
        BinaryWriter bw = new BinaryWriter(output);
        bw.WriteUTF8(SessionId);
        bw.WriteUInt32Be(LoginTime);
    }
}

