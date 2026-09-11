using wormix_core.Extensions;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Wormix.Messages.Structures;

public struct ShopItemStructure() : ISerializable
{
    public const int RealMoney = 0;
    public const int Money = 1;

    public uint Id;
    public int Count = 0;
    public int MoneyType;
    
    public uint GetSize()
    {
        return (uint)(
            // Id
            4 +
            // Count
            4 +
            // MoneyType
            4
        );
    }

    public void Serialize(Stream output)
    {
        BinaryWriter bw = new BinaryWriter(output);
        bw.WriteUInt32Be(Id);
        bw.WriteUInt32Be((uint)Count);
        bw.WriteUInt32Be((uint)MoneyType);
    }

    public void Deserialize(Stream input)
    {
        BinaryReader br = new BinaryReader(input);
        Id = br.ReadUInt32Be();
        Count = (int)br.ReadUInt32Be();
        MoneyType = (int)br.ReadUInt32Be();
    }
}
