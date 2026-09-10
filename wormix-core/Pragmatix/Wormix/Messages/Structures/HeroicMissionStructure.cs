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
}

