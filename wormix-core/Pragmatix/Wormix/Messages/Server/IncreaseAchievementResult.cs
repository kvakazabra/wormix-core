using wormix_core.Extensions;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Wormix.Messages.Server;

public struct IncreaseAchievementResult() : ISerializable
{
    public List<int> AchievementsIndex = new();
    public List<int> AchievementsValues = new();
    public List<int> ThresholdAchievmensIndex = new();
    public List<int> ThresholdAchievmensOldValues = new();
    public List<int> BoolAchievements = new();
    public uint TimeSequence;
    public byte InvestedAwardPoints;

    public uint GetSize()
    {
        return (uint)(
            // AchievementsIndex
            2 + 4 * AchievementsIndex.Count +
            // AchievementsValues
            2 + 4 * AchievementsValues.Count +
            // ThresholdAchievmensIndex
            2 + 4 * ThresholdAchievmensIndex.Count +
            // ThresholdAchievmensOldValues
            2 + 4 * ThresholdAchievmensOldValues.Count +
            // BoolAchievements
            2 + 4 * BoolAchievements.Count +
            // TimeSequence
            4 +
            // InvestedAwardPoints
            1
        );
    }

    public void Serialize(Stream output)
    {
        BinaryWriter bw = new BinaryWriter(output);

        bw.WriteUInt16Be((ushort)AchievementsIndex.Count);
        AchievementsIndex.ForEach((x) => bw.WriteUInt32Be((uint)x));

        bw.WriteUInt16Be((ushort)AchievementsValues.Count);
        AchievementsValues.ForEach((x) => bw.WriteUInt32Be((uint)x));

        bw.WriteUInt16Be((ushort)ThresholdAchievmensIndex.Count);
        ThresholdAchievmensIndex.ForEach((x) => bw.WriteUInt32Be((uint)x));

        bw.WriteUInt16Be((ushort)ThresholdAchievmensOldValues.Count);
        ThresholdAchievmensOldValues.ForEach((x) => bw.WriteUInt32Be((uint)x));

        bw.WriteUInt16Be((ushort)BoolAchievements.Count);
        BoolAchievements.ForEach((x) => bw.WriteUInt32Be((uint)x));

        bw.WriteUInt32Be(TimeSequence);
        bw.Write(InvestedAwardPoints);
    }

    public void Deserialize(Stream input)
    {
        throw new NotSupportedException();
    }
}
