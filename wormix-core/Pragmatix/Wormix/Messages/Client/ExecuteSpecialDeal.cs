using wormix_core.Extensions;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Wormix.Messages.Client;

public struct ExecuteSpecialDeal() : ISerializable
{
    public short ItemId;
    public byte RubyPrice;

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
        ItemId = (short)br.ReadUInt16Be();
        RubyPrice = br.ReadByte();
    }
}
