using wormix_core.Extensions;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Wormix.Messages.Structures;

public struct MercenariesTeamMember : ISerializable
{
    public byte Id;
    public byte Level;
    public byte Race;
    public byte Armor;
    public byte Attack;
    public short Hat;
    public short Art;
    public short Skin;
    public bool Active;
    public List<BackpackItemShortStructure> Backpack;

    public uint GetSize()
    {
        uint backpackSize = 0;
        foreach (var item in Backpack)
        {
            backpackSize += 2 + item.GetSize();
        }

        return (uint)(
            backpackSize +
            // Id
            1 +
            // Level
            1 +
            // Race
            1 +
            // Armor
            1 +
            // Attack
            1 +
            // Hat
            2 +
            // Art
            2 +
            // Skin
            2 +
            // Active
            1 +
            2
        );
    }

    public void Serialize(Stream output)
    {
        BinaryWriter bw = new BinaryWriter(output);
        bw.Write(Id);
        bw.Write(Level);
        bw.Write(Race);
        bw.Write(Armor);
        bw.Write(Attack);
        bw.WriteUInt16Be((ushort)Hat);
        bw.WriteUInt16Be((ushort)Art);
        bw.WriteUInt16Be((ushort)Skin);
        bw.Write((byte)(Active ? 1 : 0));
        bw.WriteUInt16Be((ushort)Backpack.Count);
        foreach (var item in Backpack)
        {
            bw.WriteUInt16Be(0);
            item.Serialize(output);
        }
    }
}

