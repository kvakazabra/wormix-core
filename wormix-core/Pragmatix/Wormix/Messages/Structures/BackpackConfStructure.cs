using wormix_core.Extensions;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Wormix.Messages.Structures;

public struct BackpackConfStructure : ISerializable
{
    public List<short> Config;

    public uint GetSize()
    {
        return (uint)(
            // config count prefix
            2 +
            // config shorts
            2 * (uint)Config.Count
        );
    }

    public void Serialize(Stream output)
    {
        BinaryWriter bw = new BinaryWriter(output);
        bw.WriteUInt16Be((ushort)Config.Count);
        foreach (short val in Config)
            bw.WriteUInt16Be((ushort)val);
    }

    public void Deserialize(Stream input)
    {
        BinaryReader br = new BinaryReader(input);
        Config = new List<short>();
        ushort count = br.ReadUInt16Be();
        for (int i = 0; i < count; i++)
            Config.Add((short)br.ReadUInt16Be());
    }
}
