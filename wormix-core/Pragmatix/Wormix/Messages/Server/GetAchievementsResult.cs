using wormix_core.Extensions;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Wormix.Messages.Server;

public struct GetAchievementsResult() : ISerializable
{
    public string ProfileId = "";
    public List<int> AchievementsIndex = new();
    public List<int> Achievements = new();
    public List<int> BoolAchievements = new();
    public byte InvestedAwardPoints;

    public uint GetSize()
    {
        return (uint)(
            // ProfileId
            2 + System.Text.Encoding.UTF8.GetByteCount(ProfileId) +
            // AchievementsIndex
            2 + 4 * AchievementsIndex.Count +
            // Achievements
            2 + 4 * Achievements.Count +
            // BoolAchievements
            2 + 4 * BoolAchievements.Count +
            // InvestedAwardPoints
            1
        );
    }

    public void Serialize(Stream output)
    {
        BinaryWriter bw = new BinaryWriter(output);

        bw.WriteUTF8(ProfileId);

        bw.WriteUInt16Be((ushort)AchievementsIndex.Count);
        AchievementsIndex.ForEach((x) => bw.WriteUInt32Be((uint)x));

        bw.WriteUInt16Be((ushort)Achievements.Count);
        Achievements.ForEach((x) => bw.WriteUInt32Be((uint)x));

        bw.WriteUInt16Be((ushort)BoolAchievements.Count);
        BoolAchievements.ForEach((x) => bw.WriteUInt32Be((uint)x));

        bw.Write(InvestedAwardPoints);
    }

    public void Deserialize(Stream input)
    {
        throw new NotSupportedException();
    }
}
