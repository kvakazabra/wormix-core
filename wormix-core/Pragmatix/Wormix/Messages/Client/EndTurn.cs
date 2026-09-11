using wormix_core.Extensions;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;
using wormix_core.Pragmatix.Wormix.Messages.Structures;

namespace wormix_core.Pragmatix.Wormix.Messages.Client;

public struct EndTurn() : ISerializable
{
    public short MissionId;
    public uint BattleId;
    public short RandomSeed;
    public TurnStructure Turn = new();
    public short BanType;
    public string BanNote = "";
    public string SessionKey = "";

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
        MissionId = (short)br.ReadUInt16Be();
        BattleId = br.ReadUInt32Be();
        RandomSeed = (short)br.ReadUInt16Be();
        br.ReadUInt16Be();
        Turn.TurnNum = (short)br.ReadUInt16Be();
        Turn.IsPlayerTurn = br.ReadByte() != 0;
        Turn.EndTime = (int)br.ReadUInt32Be();
        Turn.DamageToPlayer = (int)br.ReadUInt32Be();
        Turn.DamageToBoss = (int)br.ReadUInt32Be();
        ushort itemsCount = br.ReadUInt16Be();
        for (int i = 0; i < itemsCount; i++)
        {
            br.ReadUInt16Be();
            WeaponStructure item = new();
            item.Id = br.ReadUInt32Be();
            item.Count = (int)br.ReadUInt32Be();
            Turn.Items.Add(item);
        }
        ushort deathsCount = br.ReadUInt16Be();
        for (int i = 0; i < deathsCount; i++)
        {
            br.ReadUInt16Be();
            BossWormStructure death = new();
            death.IsPlayerTeam = br.ReadByte() != 0;
            death.Hp = (int)br.ReadUInt32Be();
            Turn.Deaths.Add(death);
        }
        ushort birthsCount = br.ReadUInt16Be();
        for (int i = 0; i < birthsCount; i++)
        {
            br.ReadUInt16Be();
            BossWormStructure birth = new();
            birth.IsPlayerTeam = br.ReadByte() != 0;
            birth.Hp = (int)br.ReadUInt32Be();
            Turn.Births.Add(birth);
        }
        BanType = (short)br.ReadUInt16Be();
        BanNote = br.ReadUTF8();
        SessionKey = br.ReadUTF8();
    }
}
