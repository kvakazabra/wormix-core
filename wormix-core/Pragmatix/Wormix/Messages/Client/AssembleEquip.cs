using wormix_core.Extensions;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Wormix.Messages.Client;

public struct AssembleEquip() : ISerializable
{
    public short FamilyId;
    public short MoneyType;

    public uint GetSize()
    {
        return 0; //Not needed
    }

    public void Serialize(Stream output)
    {
        throw new NotSupportedException();
    }

    public void Deserialize(Stream input)
    {
        BinaryReader br = new BinaryReader(input);
        FamilyId = (short)br.ReadUInt16Be();
        MoneyType = (short)br.ReadUInt16Be();
    }
}
