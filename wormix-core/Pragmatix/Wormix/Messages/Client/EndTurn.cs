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
        //Not needed
    }
}