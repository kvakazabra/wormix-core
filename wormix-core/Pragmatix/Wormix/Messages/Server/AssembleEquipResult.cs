using wormix_core.Extensions;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Wormix.Messages.Server;

public struct AssembleEquipResult() : ISerializable
{
    public short EquipId;
    public short FamilyId;
    public short Result;

    public uint GetSize()
    {
        return (uint)(
            // EquipId
            2 +
            // FamilyId
            2 +
            // Result
            2
        );
    }

    public void Serialize(Stream output)
    {
        BinaryWriter bw = new BinaryWriter(output);
        bw.WriteUInt16Be((ushort)EquipId);
        bw.WriteUInt16Be((ushort)FamilyId);
        bw.WriteUInt16Be((ushort)Result);
    }

    public void Deserialize(Stream input)
    {
        throw new NotSupportedException();
    }
}
