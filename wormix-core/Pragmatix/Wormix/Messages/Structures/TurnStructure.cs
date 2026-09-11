using wormix_core.Extensions;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Wormix.Messages.Structures;

public struct TurnStructure() : ISerializable
{
    public int TurnNum;
    public bool IsPlayerTurn;
    public int EndTime;
    public int DamageToPlayer;
    public int DamageToBoss;
    public List<WeaponStructure> Items = new();
    public List<BossWormStructure> Deaths = new();
    public List<BossWormStructure> Births = new();

    public uint GetSize()
    {
        return (uint)(
            // TurnNum
            2 +
            // IsPlayerTurn
            1 +
            // EndTime
            4 +
            // DamageToPlayer
            4 +
            // DamageToBoss
            4 +
            // Items
            2 + Items.Sum(el => 2 + el.GetSize()) +
            // Deaths
            2 + Deaths.Sum(el => 2 + el.GetSize()) +
            // Births[]
            2 + Births.Sum(el => 2 + el.GetSize())
        );
    }

    public void Serialize(Stream output)
    {
        BinaryWriter bw = new BinaryWriter(output);
        bw.WriteUInt16Be((ushort)TurnNum);
        bw.Write((byte)(IsPlayerTurn ? 1 : 0));
        bw.WriteUInt32Be((uint)EndTime);
        bw.WriteUInt32Be((uint)DamageToPlayer);
        bw.WriteUInt32Be((uint)DamageToBoss);

        bw.WriteUInt16Be((ushort)Items.Count);
        Items.ForEach((el) =>
        {
            bw.WriteUInt16Be(0);
            el.Serialize(output);
        });

        bw.WriteUInt16Be((ushort)Deaths.Count);
        Deaths.ForEach((el) =>
        {
            bw.WriteUInt16Be(0);
            el.Serialize(output);
        });

        bw.WriteUInt16Be((ushort)Births.Count);
        Births.ForEach((el) =>
        {
            bw.WriteUInt16Be(0);
            el.Serialize(output);
        });
    }

    public void Deserialize(Stream input)
    {
        BinaryReader br = new BinaryReader(input);
        TurnNum = (int)br.ReadUInt16Be();
        IsPlayerTurn = br.ReadByte() != 0;
        EndTime = (int)br.ReadUInt32Be();
        DamageToPlayer = (int)br.ReadUInt32Be();
        DamageToBoss = (int)br.ReadUInt32Be();

        Items = new List<WeaponStructure>();
        ushort itemsCount = br.ReadUInt16Be();
        for (int i = 0; i < itemsCount; i++)
        {
            br.ReadUInt16Be();
            WeaponStructure item = new WeaponStructure();
            item.Deserialize(input);
            Items.Add(item);
        }

        Deaths = new List<BossWormStructure>();
        ushort deathsCount = br.ReadUInt16Be();
        for (int i = 0; i < deathsCount; i++)
        {
            br.ReadUInt16Be();
            BossWormStructure death = new BossWormStructure();
            death.Deserialize(input);
            Deaths.Add(death);
        }

        Births = new List<BossWormStructure>();
        ushort birthsCount = br.ReadUInt16Be();
        for (int i = 0; i < birthsCount; i++)
        {
            br.ReadUInt16Be();
            BossWormStructure birth = new BossWormStructure();
            birth.Deserialize(input);
            Births.Add(birth);
        }
    }
}
