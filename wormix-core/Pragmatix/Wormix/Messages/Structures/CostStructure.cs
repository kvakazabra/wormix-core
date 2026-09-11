using wormix_core.Extensions;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Wormix.Messages.Structures;

public struct CostStructure : ISerializable
{
    public const int RealMoney = 0;
    public const int Money = 1;
    public const int BattleTokens = 2;
    public const int Reagents = 3;

    public short CurrencyType;
    public int ItemId;
    public int Value;

    public uint GetSize()
    {
        return (uint)(
            // CurrencyType
            2 +
            // ItemId
            4 +
            // Value
            4
        );
    }

    public void Serialize(Stream output)
    {
        BinaryWriter bw = new BinaryWriter(output);
        bw.WriteUInt16Be((ushort)CurrencyType);
        bw.WriteUInt32Be((uint)ItemId);
        bw.WriteUInt32Be((uint)Value);
    }

    public void Deserialize(Stream input)
    {
        BinaryReader br = new BinaryReader(input);
        CurrencyType = (short)br.ReadUInt16Be();
        ItemId = (int)br.ReadUInt32Be();
        Value = (int)br.ReadUInt32Be();
    }
}
