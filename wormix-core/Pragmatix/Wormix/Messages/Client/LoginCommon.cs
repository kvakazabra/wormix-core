using wormix_core.Extensions;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Wormix.Messages.Client;

public struct LoginCommon() : ISerializable
{
    public string AuthKey = "";
    public string Version = "";
    public List<uint> Ids = new();
    public byte SocialCode;
    public List<string> Params = new();

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
        throw new NotImplementedException();
    }
}
