using wormix_core.Extensions;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;
using wormix_core.Pragmatix.Wormix.Messages.Structures;

namespace wormix_core.Pragmatix.Wormix.Messages.Server;

public struct ArenaResult() : ISerializable
{
    public int BattlesCount;
    public short CurSoloMissionId;
    public short CurCooperativeMissionId;
    public bool BossAvailable;
    public bool SuperBossAvailable;
    public List<HeroicMissionStructure> HeroicStructures = new();
    public uint Delay;
    public uint RestoreBattlesDelay;
    public List<short> RestrictedWagers = new();
    public List<uint> RestrictedWagersLeftTime = new();
    public List<HeroicMissionDailyProgressTO> HeroicMissionDailyProgress = new();
    public int DefeatContributionMoney;
    public string ExtraBattlesTimetable = "";
    public int WagerWinAwardToken;
    public int BossWinAwardToken;
    public BossBattleAwardsStructure BossAwardsStructure = new();
    public int ZombieRiseCoolDownTime;

    public uint GetSize()
    {
        return (uint)(
            // BattlesCount
            4 +
            // CurSoloMissionId
            2 +
            // CurCooperativeMissionId
            2 +
            // BossAvailable
            1 +
            // SuperBossAvailable
            1 +
            // HeroicStructures
            2 + HeroicStructures.Sum((x) => x.GetSize() + 2) +
            // Delay
            4 +
            // RestoreBattlesDelay
            4 +
            // RestrictedWagers
            2 + 2 * RestrictedWagers.Count +
            // RestrictedWagersLeftTime
            2 + 4 * RestrictedWagersLeftTime.Count +
            // HeroicMissionDailyProgress[]
            2 + HeroicMissionDailyProgress.Sum((x) => x.GetSize() + 2) +
            4 +
            // ExtraBattlesTimetable
            2 + System.Text.Encoding.UTF8.GetByteCount(ExtraBattlesTimetable) +
            4 +
            4 +
            // BossAwardsStructure
            2 + BossAwardsStructure.GetSize() +
            4
        );
    }

    public void Serialize(Stream output)
    {
        BinaryWriter bw = new BinaryWriter(output);
        bw.WriteUInt32Be((uint)BattlesCount);
        bw.WriteUInt16Be((ushort)CurSoloMissionId);
        bw.WriteUInt16Be((ushort)CurCooperativeMissionId);
        bw.Write(BossAvailable);
        bw.Write(SuperBossAvailable);

        bw.WriteUInt16Be((ushort)HeroicStructures.Count);
        HeroicStructures.ForEach((x) =>
        {
            bw.WriteUInt16Be((ushort)x.GetSize());
            x.Serialize(output);
        });

        bw.WriteUInt32Be(Delay);
        bw.WriteUInt32Be(RestoreBattlesDelay);

        bw.WriteUInt16Be((ushort)RestrictedWagers.Count);
        RestrictedWagers.ForEach((x) => bw.WriteUInt16Be((ushort)x));

        bw.WriteUInt16Be((ushort)RestrictedWagersLeftTime.Count);
        RestrictedWagersLeftTime.ForEach((x) => bw.WriteUInt32Be(x));

        bw.WriteUInt16Be((ushort)HeroicMissionDailyProgress.Count);
        HeroicMissionDailyProgress.ForEach((x) =>
        {
            bw.WriteUInt16Be((ushort)x.GetSize());
            x.Serialize(output);
        });

        bw.WriteUInt32Be((uint)DefeatContributionMoney);
        bw.WriteUTF8(ExtraBattlesTimetable);
        bw.WriteUInt32Be((uint)WagerWinAwardToken);
        bw.WriteUInt32Be((uint)BossWinAwardToken);

        bw.WriteUInt16Be((ushort)BossAwardsStructure.GetSize());
        BossAwardsStructure.Serialize(output);

        bw.WriteUInt32Be((uint)ZombieRiseCoolDownTime);
    }

    public void Deserialize(Stream input)
    {
        throw new NotSupportedException();
    }
}
