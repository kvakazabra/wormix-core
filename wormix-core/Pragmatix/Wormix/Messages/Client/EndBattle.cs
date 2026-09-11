using wormix_core.Extensions;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;
using wormix_core.Pragmatix.Wormix.Messages.Structures;

namespace wormix_core.Pragmatix.Wormix.Messages.Client;

public struct EndBattle() : ISerializable
{
    public uint Result;
    public short Type;
    public int ExpBonus;
    public uint BattleId;
    public short MissionId;
    public List<WeaponStructure> Items = new();
    public short BanType;
    public string BanNote = "";
    public List<byte> CollectedReagents = new();
    public short RandomSeed;
    public short TotalTurnsCount;
    public int TotalDamageToPlayer;
    public int TotalDamageToBoss;
    public List<WeaponStructure> TotalUsedItems = new();
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
        Result = br.ReadUInt32Be();
        Type = (short)br.ReadUInt16Be();
        ExpBonus = (int)br.ReadUInt32Be();
        BattleId = br.ReadUInt32Be();
        MissionId = (short)br.ReadUInt16Be();
        ushort itemsCount = br.ReadUInt16Be();
        for (int i = 0; i < itemsCount; i++)
        {
            br.ReadUInt16Be();
            WeaponStructure item = new();
            item.Id = br.ReadUInt32Be();
            item.Count = (int)br.ReadUInt32Be();
            Items.Add(item);
        }
        BanType = (short)br.ReadUInt16Be();
        BanNote = br.ReadUTF8();
        ushort reagentsCount = br.ReadUInt16Be();
        for (int i = 0; i < reagentsCount; i++)
            CollectedReagents.Add(br.ReadByte());
        RandomSeed = (short)br.ReadUInt16Be();
        TotalTurnsCount = (short)br.ReadUInt16Be();
        TotalDamageToPlayer = (int)br.ReadUInt32Be();
        TotalDamageToBoss = (int)br.ReadUInt32Be();
        ushort usedItemsCount = br.ReadUInt16Be();
        for (int i = 0; i < usedItemsCount; i++)
        {
            br.ReadUInt16Be();
            WeaponStructure item = new();
            item.Id = br.ReadUInt32Be();
            item.Count = (int)br.ReadUInt32Be();
            TotalUsedItems.Add(item);
        }
        SessionKey = br.ReadUTF8();
    }
}
