using wormix_core.Extensions;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Wormix.Messages.Client;

public struct LoginByProfileStringId() : ISerializable
{
    public string Id = "";
    public string ReferrerId = "";
    public string AuthKey = "";
    public string Version = "";
    public List<string> Ids = new();
    public byte SocialCode;
    public List<string> Params = new();

    public uint GetSize()
    {
        return 0; //Not needed
    }

    public void Serialize(Stream output)
    {
        //Not needed
    }
}
