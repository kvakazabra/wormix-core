using wormix_core.Extensions;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Wormix.Messages.Structures;

public struct BackpackItemShortStructure : ISerializable
{
    public short WeaponId;
    public short Count;

    public uint GetSize()
    {
        return (uint)(
            // WeaponId
            2 +
            // Count
            2
        );
    }

    public void Serialize(Stream output)
    {
        BinaryWriter bw = new BinaryWriter(output);
        bw.WriteUInt16Be((ushort)WeaponId);
        bw.WriteUInt16Be((ushort)Count);
    }

    public void Deserialize(Stream input)
    {
        BinaryReader br = new BinaryReader(input);
        WeaponId = (short)br.ReadUInt16Be();
        Count = (short)br.ReadUInt16Be();
    }
}
