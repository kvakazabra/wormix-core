using wormix_core.Extensions;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Wormix.Messages.Client;

public struct GetProfiles() : ISerializable
{
    public string SessionKey = "";
    public List<string> Ids = new();

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
        SessionKey = br.ReadUTF8();
        ushort n = br.ReadUInt16Be();
        for (int i = 0; i < n; i++)
            Ids.Add(br.ReadUTF8());
    }
}
