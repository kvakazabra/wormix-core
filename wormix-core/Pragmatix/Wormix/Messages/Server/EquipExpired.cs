using wormix_core.Extensions;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Wormix.Messages.Server;

public struct EquipExpired() : ISerializable
{
    public List<short> EquipIds = new();
    public short HatId;
    public short ArtifactId;

    public uint GetSize()
    {
        return (uint)(
            // EquipIds
            2 + 2 * EquipIds.Count +
            // HatId
            2 +
            // ArtifactId
            2
        );
    }

    public void Serialize(Stream output)
    {
        BinaryWriter bw = new BinaryWriter(output);

        bw.WriteUInt16Be((ushort)EquipIds.Count);
        EquipIds.ForEach((x) => bw.WriteUInt16Be((ushort)x));

        bw.WriteUInt16Be((ushort)HatId);
        bw.WriteUInt16Be((ushort)ArtifactId);
    }
}

