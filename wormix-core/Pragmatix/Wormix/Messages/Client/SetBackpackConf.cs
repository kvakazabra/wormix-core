using wormix_core.Extensions;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;
using wormix_core.Pragmatix.Wormix.Messages.Structures;

namespace wormix_core.Pragmatix.Wormix.Messages.Client;

public struct SetBackpackConf() : ISerializable
{
    public List<BackpackConfStructure> Configs = new();
    public byte ActiveConfig;

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
        ushort n = br.ReadUInt16Be();
        for (int i = 0; i < n; i++)
        {
            ushort size = br.ReadUInt16Be();
            BackpackConfStructure s = new();
            ushort count = br.ReadUInt16Be();
            s.Config = new List<short>();
            for (int j = 0; j < count; j++)
                s.Config.Add((short)br.ReadUInt16Be());
            Configs.Add(s);
        }
        ActiveConfig = br.ReadByte();
    }
}
