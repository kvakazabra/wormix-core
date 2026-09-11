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
        throw new NotSupportedException();
    }

    public void Deserialize(Stream input)
    {
        BinaryReader br = new BinaryReader(input);
        Id = br.ReadUTF8();
        ReferrerId = br.ReadUTF8();
        AuthKey = br.ReadUTF8();
        Version = ParseVersion((int)br.ReadUInt32Be());
        ushort n = br.ReadUInt16Be();
        for (int i = 0; i < n; i++)
            Ids.Add(br.ReadUTF8());
        SocialCode = br.ReadByte();
        n = br.ReadUInt16Be();
        for (int i = 0; i < n; i++)
            Params.Add(br.ReadUTF8());
    }

    private static string ParseVersion(int version)
    {
        int b0 = (version >> 24) & 0xFF;
        int b1 = (version >> 16) & 0xFF;
        int b2 = (version >> 8) & 0xFF;
        int b3 = version & 0xFF;
        return $"{b0}.{b1}.{b2}.{b3}";
    }
}
