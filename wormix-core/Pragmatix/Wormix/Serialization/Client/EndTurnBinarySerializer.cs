using wormix_core.Extensions;
using wormix_core.Pragmatix.Flox.Serialization.Interfaces;
using wormix_core.Pragmatix.Wormix.Messages.Client;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;
using wormix_core.Pragmatix.Wormix.Messages.Structures;

namespace wormix_core.Pragmatix.Wormix.Serialization.Client;

public class EndTurnBinarySerializer : ICommandSerializer
{
    public uint GetCommandId()
    {
        return 120;
    }

    public void SerializeCommand(ISerializable command, Stream output)
    {
        //Not needed
    }

    public ISerializable DeserializeCommand(Stream input, ICommandHeader header)
    {
        EndTurn msg = new();

        BinaryReader br = new BinaryReader(input);
        msg.MissionId = (short)br.ReadUInt16Be();
        msg.BattleId = br.ReadUInt32Be();
        msg.RandomSeed = (short)br.ReadUInt16Be();
        br.ReadUInt16Be();
        msg.Turn.TurnNum = (short)br.ReadUInt16Be();
        msg.Turn.IsPlayerTurn = br.ReadByte() != 0;
        msg.Turn.EndTime = (int)br.ReadUInt32Be();
        msg.Turn.DamageToPlayer = (int)br.ReadUInt32Be();
        msg.Turn.DamageToBoss = (int)br.ReadUInt32Be();
        ushort itemsCount = br.ReadUInt16Be();
        for (int i = 0; i < itemsCount; i++)
        {
            br.ReadUInt16Be();
            WeaponStructure item = new();
            item.Id = br.ReadUInt32Be();
            item.Count = (int)br.ReadUInt32Be();
            msg.Turn.Items.Add(item);
        }
        ushort deathsCount = br.ReadUInt16Be();
        for (int i = 0; i < deathsCount; i++)
        {
            br.ReadUInt16Be();
            BossWormStructure death = new();
            death.IsPlayerTeam = br.ReadByte() != 0;
            death.Hp = (int)br.ReadUInt32Be();
            msg.Turn.Deaths.Add(death);
        }
        ushort birthsCount = br.ReadUInt16Be();
        for (int i = 0; i < birthsCount; i++)
        {
            br.ReadUInt16Be();
            BossWormStructure birth = new();
            birth.IsPlayerTeam = br.ReadByte() != 0;
            birth.Hp = (int)br.ReadUInt32Be();
            msg.Turn.Births.Add(birth);
        }
        msg.BanType = (short)br.ReadUInt16Be();
        msg.BanNote = br.ReadUTF8();
        msg.SessionKey = br.ReadUTF8();

        return msg;
    }
}
