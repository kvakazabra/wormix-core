using wormix_core.Extensions;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Wormix.Messages.Client;

public struct AchieveLogin() : ISerializable
{
    public string ApplicationId = "";
    public string SocialNetworkId = "";
    public string Id = "";
    public string AuthKey = "";
    public bool SendAchievements;

    public uint GetSize()
    {
        return 0; //Not needed
    }

    public void Serialize(Stream output)
    {
        //Not needed
    }
}