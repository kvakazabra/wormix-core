using wormix_core.Extensions;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Wormix.Messages.Client;

public struct BuyBattle() : ISerializable
{
    public int MoneyType;
    public bool Bulk;

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
        MoneyType = (int)br.ReadUInt32Be();
        Bulk = br.ReadByte() != 0;
    }
}
