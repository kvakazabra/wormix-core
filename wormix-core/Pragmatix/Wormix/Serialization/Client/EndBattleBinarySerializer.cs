using wormix_core.Extensions;
using wormix_core.Pragmatix.Flox.Serialization.Interfaces;
using wormix_core.Pragmatix.Wormix.Messages.Client;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;
using wormix_core.Pragmatix.Wormix.Messages.Structures;

namespace wormix_core.Pragmatix.Wormix.Serialization.Client;

public class EndBattleBinarySerializer : ICommandSerializer
{
    public uint GetCommandId()
    {
        return 84;
    }

    public void SerializeCommand(ISerializable command, Stream output)
    {
        //Not needed
    }

    public ISerializable DeserializeCommand(Stream input, ICommandHeader header)
    {
        EndBattle msg = new();

        BinaryReader br = new BinaryReader(input);
        msg.Result = br.ReadUInt32Be();
        msg.Type = (short)br.ReadUInt16Be();
        msg.ExpBonus = (int)br.ReadUInt32Be();
        msg.BattleId = br.ReadUInt32Be();
        msg.MissionId = (short)br.ReadUInt16Be();
        ushort itemsCount = br.ReadUInt16Be();
        for (int i = 0; i < itemsCount; i++)
        {
            br.ReadUInt16Be();
            WeaponStructure item = new();
            item.Id = br.ReadUInt32Be();
            item.Count = (int)br.ReadUInt32Be();
            msg.Items.Add(item);
        }
        msg.BanType = (short)br.ReadUInt16Be();
        msg.BanNote = br.ReadUTF8();
        ushort reagentsCount = br.ReadUInt16Be();
        for (int i = 0; i < reagentsCount; i++)
            msg.CollectedReagents.Add(br.ReadByte());
        msg.RandomSeed = (short)br.ReadUInt16Be();
        msg.TotalTurnsCount = (short)br.ReadUInt16Be();
        msg.TotalDamageToPlayer = (int)br.ReadUInt32Be();
        msg.TotalDamageToBoss = (int)br.ReadUInt32Be();
        ushort usedItemsCount = br.ReadUInt16Be();
        for (int i = 0; i < usedItemsCount; i++)
        {
            br.ReadUInt16Be();
            WeaponStructure item = new();
            item.Id = br.ReadUInt32Be();
            item.Count = (int)br.ReadUInt32Be();
            msg.TotalUsedItems.Add(item);
        }
        msg.SessionKey = br.ReadUTF8();

        return msg;
    }
}
