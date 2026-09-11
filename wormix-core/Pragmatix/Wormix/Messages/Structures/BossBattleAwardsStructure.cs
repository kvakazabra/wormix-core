using wormix_core.Extensions;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Wormix.Messages.Structures;

public struct BossBattleAwardsStructure() : ISerializable
{
    public List<BossBattleAwardStructure> BossAwards = new();
    public List<HeroicBossBattleAwardStructure> HeroicAwards = new();

    public uint GetSize()
    {
        return (uint)(
            // BossAwards
            2 + BossAwards.Sum(el => 2 + el.GetSize()) +
            // HeroicAwards[]
            2 + HeroicAwards.Sum(el => 2 + el.GetSize())
        );
    }

    public void Serialize(Stream output)
    {
        BinaryWriter bw = new BinaryWriter(output);
        bw.WriteUInt16Be((ushort)BossAwards.Count);
        BossAwards.ForEach((el) =>
        {
            bw.WriteUInt16Be(0);
            el.Serialize(output);
        });

        bw.WriteUInt16Be((ushort)HeroicAwards.Count);
        HeroicAwards.ForEach((el) =>
        {
            bw.WriteUInt16Be(0);
            el.Serialize(output);
        });
    }

    public void Deserialize(Stream input)
    {
        BinaryReader br = new BinaryReader(input);
        BossAwards = new List<BossBattleAwardStructure>();
        ushort bossCount = br.ReadUInt16Be();
        for (int i = 0; i < bossCount; i++)
        {
            br.ReadUInt16Be();
            BossBattleAwardStructure el = new BossBattleAwardStructure();
            el.Deserialize(input);
            BossAwards.Add(el);
        }

        HeroicAwards = new List<HeroicBossBattleAwardStructure>();
        ushort heroicCount = br.ReadUInt16Be();
        for (int i = 0; i < heroicCount; i++)
        {
            br.ReadUInt16Be();
            HeroicBossBattleAwardStructure el = new HeroicBossBattleAwardStructure();
            el.Deserialize(input);
            HeroicAwards.Add(el);
        }
    }
}
