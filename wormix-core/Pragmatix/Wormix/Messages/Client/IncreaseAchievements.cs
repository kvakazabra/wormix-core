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
        //Not needed
    }
}
