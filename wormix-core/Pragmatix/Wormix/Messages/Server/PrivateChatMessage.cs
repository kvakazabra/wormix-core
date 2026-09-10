using wormix_core.Extensions;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Wormix.Messages.Server;

public struct PrivateChatMessage() : ISerializable
{
    public uint FromProfileId;
    public string Msg = "";
    public byte PredefinedMsgType;

    public uint GetSize()
    {
        return (uint)(
            // FromProfileId
            4 +
            // Msg
            2 + System.Text.Encoding.UTF8.GetByteCount(Msg) +
            // PredefinedMsgType
            1
        );
    }

    public void Serialize(Stream output)
    {
        BinaryWriter bw = new BinaryWriter(output);

        bw.WriteUInt32Be(FromProfileId);
        bw.WriteUTF8(Msg);
        bw.Write(PredefinedMsgType);
    }
}

