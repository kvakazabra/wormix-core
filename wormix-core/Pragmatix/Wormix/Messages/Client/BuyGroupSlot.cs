using wormix_core.Extensions;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Wormix.Messages.Client;

public struct BuyGroupSlot() : ISerializable
{
    public byte NewSlotIndex;
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
        NewSlotIndex = br.ReadByte();
        MoneyType = (short)br.ReadUInt16Be();
    }
}
