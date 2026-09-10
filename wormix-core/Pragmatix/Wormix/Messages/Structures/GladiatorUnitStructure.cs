using wormix_core.Extensions;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Wormix.Messages.Structures;

public struct GladiatorUnitStructure : ISerializable
{
    public int RaceId;
    public int Armor;
    public int Attack;
    public int HatId;
    public int ArtifactId;
    
    public uint GetSize()
    {
        return (uint)(
            // RaceId
            1 +
            // Armor
            1 +
            // Attack
            1 +
            // HatId
            2 +
            // ArtifactId
            2
        );
    }

    public void Serialize(Stream output)
    {
        BinaryWriter bw = new BinaryWriter(output);
        bw.Write((byte)RaceId);
        bw.Write((byte)Armor);
        bw.Write((byte)Attack);
        bw.WriteUInt16Be((ushort)HatId);
        bw.WriteUInt16Be((ushort)ArtifactId);
    }
}

