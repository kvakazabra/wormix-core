using wormix_core.Extensions;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Wormix.Messages.Structures;

public struct GenericAwardStructure : ISerializable
{
    public short AwardKind;
    public int Count;
    public int ItemId;

    public uint GetSize()
    {
        return (uint)(
            // AwardKind
            2 +
            // Count
            4 +
            // ItemId
            4
        );
    }

    public void Serialize(Stream output)
    {
        BinaryWriter bw = new BinaryWriter(output);
        bw.WriteUInt16Be((ushort)AwardKind);
        bw.WriteUInt32Be((uint)Count);
        bw.WriteUInt32Be((uint)ItemId);
    }
}

