using wormix_core.Extensions;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Wormix.Messages.Server;

public struct ItemGranted() : ISerializable
{
    public int ItemId;
    public int ItemCount;
    public string SessionId = "";

    public uint GetSize()
    {
        return (uint)(
            // ItemId
            4 +
            // ItemCount
            4 +
            // SessionId
            2 + System.Text.Encoding.UTF8.GetByteCount(SessionId)
        );
    }

    public void Serialize(Stream output)
    {
        BinaryWriter bw = new BinaryWriter(output);

        bw.WriteUInt32Be((uint)ItemId);
        bw.WriteUInt32Be((uint)ItemCount);
        bw.WriteUTF8(SessionId);
    }
}

