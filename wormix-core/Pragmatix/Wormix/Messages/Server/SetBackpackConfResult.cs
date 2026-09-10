using wormix_core.Extensions;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;
using wormix_core.Pragmatix.Wormix.Messages.Structures;

namespace wormix_core.Pragmatix.Wormix.Messages.Server;

public struct SetBackpackConfResult() : ISerializable
{
    public short Result;
    public List<BackpackConfStructure> Configs = new();
    public byte ActiveConfig;

    public uint GetSize()
    {
        return (uint)(
            // Result
            2 +
            // Configs[]
            2 + Configs.Sum((x) => x.GetSize() + 2) +
            // ActiveConfig
            1
        );
    }

    public void Serialize(Stream output)
    {
        BinaryWriter bw = new BinaryWriter(output);
        bw.WriteUInt16Be((ushort)Result);

        bw.WriteUInt16Be((ushort)Configs.Count);
        Configs.ForEach((x) =>
        {
            bw.WriteUInt16Be((ushort)x.GetSize());
            x.Serialize(output);
        });

        bw.Write(ActiveConfig);
    }
}

