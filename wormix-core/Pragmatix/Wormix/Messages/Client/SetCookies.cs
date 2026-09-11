using wormix_core.Extensions;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Wormix.Messages.Client;

public struct SetCookies() : ISerializable
{
    public List<string> Names = new();
    public List<string> Values = new();

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
        ushort n1 = br.ReadUInt16Be();
        for (int i = 0; i < n1; i++)
            Names.Add(br.ReadUTF8());
        ushort n2 = br.ReadUInt16Be();
        for (int i = 0; i < n2; i++)
            Values.Add(br.ReadUTF8());
    }
}
