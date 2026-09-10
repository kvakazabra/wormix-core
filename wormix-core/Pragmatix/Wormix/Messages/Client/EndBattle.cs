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
        //Not needed
    }
}