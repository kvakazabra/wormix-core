using wormix_core.Extensions;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Wormix.Messages.Structures;

public struct BossBattleWinAwardStructure() : ISerializable
{
    public int Money;
    public int RealMoney;
    public int Experience;
    public List<AwardBackpackItemStructure> AwardItems = new();

    public uint GetSize()
    {
        return (uint)(
            // Money
            4 +
            // RealMoney
            4 +
            // Experience
            4 +
            // AwardItems[]
            2 + AwardItems.Sum(el => 2 + el.GetSize())
        );
    }

    public void Serialize(Stream output)
    {
        BinaryWriter bw = new BinaryWriter(output);
        bw.WriteUInt32Be((uint)Money);
        bw.WriteUInt32Be((uint)RealMoney);
        bw.WriteUInt32Be((uint)Experience);

        bw.WriteUInt16Be((ushort)AwardItems.Count);
        AwardItems.ForEach((el) =>
        {
            bw.WriteUInt16Be(0);
            el.Serialize(output);
        });
    }

    public void Deserialize(Stream input)
    {
        BinaryReader br = new BinaryReader(input);
        Money = (int)br.ReadUInt32Be();
        RealMoney = (int)br.ReadUInt32Be();
        Experience = (int)br.ReadUInt32Be();
        AwardItems = new List<AwardBackpackItemStructure>();
        ushort count = br.ReadUInt16Be();
        for (int i = 0; i < count; i++)
        {
            br.ReadUInt16Be();
            AwardBackpackItemStructure item = new AwardBackpackItemStructure();
            item.Deserialize(input);
            AwardItems.Add(item);
        }
    }
}
