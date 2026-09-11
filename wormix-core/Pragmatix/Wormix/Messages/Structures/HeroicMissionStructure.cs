using wormix_core.Extensions;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Wormix.Messages.Structures;

public struct HeroicMissionStructure() : ISerializable
{
    public List<int> BossIds = new();
    public uint MapId;

    public uint GetSize()
    {
        return (uint)(
            // BossIds
            2 + 2 * BossIds.Count +
            // MapId
            4
        );
    }

    public void Serialize(Stream output)
    {
        BinaryWriter bw = new BinaryWriter(output);
        bw.WriteUInt16Be((ushort)BossIds.Count);
        BossIds.ForEach((x) => bw.WriteUInt16Be((ushort)x));
        bw.WriteUInt32Be(MapId);
    }

    public void Deserialize(Stream input)
    {
        BinaryReader br = new BinaryReader(input);
        BossIds = new List<int>();
        ushort count = br.ReadUInt16Be();
        for (int i = 0; i < count; i++)
            BossIds.Add((short)br.ReadUInt16Be());
        MapId = br.ReadUInt32Be();
    }
}
