using wormix_core.Extensions;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;
using wormix_core.Pragmatix.Wormix.Messages.Structures;

namespace wormix_core.Pragmatix.Wormix.Messages.Server;

public struct SellStuffResult() : ISerializable
{
    public List<int> StuffIds = new();
    public List<GenericAwardStructure> Awards = new();
    public string SessionKey = "";

    public uint GetSize()
    {
        return (uint)(
            // StuffIds[]
            2 + 4 * StuffIds.Count +
            // Awards[]
            2 + Awards.Sum((x) => x.GetSize() + 2) +
            // SessionKey
            2 + System.Text.Encoding.UTF8.GetByteCount(SessionKey)
        );
    }

    public void Serialize(Stream output)
    {
        BinaryWriter bw = new BinaryWriter(output);
        bw.WriteUInt16Be((ushort)StuffIds.Count);
        StuffIds.ForEach((x) => bw.WriteUInt32Be((uint)x));

        bw.WriteUInt16Be((ushort)Awards.Count);
        Awards.ForEach((x) =>
        {
            bw.WriteUInt16Be((ushort)x.GetSize());
            x.Serialize(output);
        });

        bw.WriteUTF8(SessionKey);
    }
}

