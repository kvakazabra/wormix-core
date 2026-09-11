using wormix_core.Extensions;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Wormix.Messages.Client;

public struct NeedMoney() : ISerializable
{
    public int Value;
    public int MoneyType;

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
        Value = (int)br.ReadUInt32Be();
        MoneyType = (int)br.ReadUInt32Be();
    }
}
