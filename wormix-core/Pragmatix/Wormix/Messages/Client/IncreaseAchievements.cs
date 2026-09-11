using wormix_core.Extensions;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Wormix.Messages.Client;

public struct IncreaseAchievements() : ISerializable
{
    public string SessionId = "";
    public List<int> AchievementsIndex = new();
    public List<int> AchievementsRise = new();
    public List<int> BoolAchievements = new();
    public uint TimeScale;

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
        SessionId = br.ReadUTF8();
        ushort n = br.ReadUInt16Be();
        for (int i = 0; i < n; i++)
            AchievementsIndex.Add((int)br.ReadUInt32Be());
        n = br.ReadUInt16Be();
        for (int i = 0; i < n; i++)
            AchievementsRise.Add((int)br.ReadUInt32Be());
        n = br.ReadUInt16Be();
        for (int i = 0; i < n; i++)
            BoolAchievements.Add((int)br.ReadUInt32Be());
        TimeScale = br.ReadUInt32Be();
    }
}
