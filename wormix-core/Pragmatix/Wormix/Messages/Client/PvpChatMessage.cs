using wormix_core.Extensions;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Wormix.Messages.Client;

public struct PvpChatMessage() : ISerializable
{
    public byte PlayerNum;
    public short Action;
    public string Message = "";
    public uint BattleId;
    public bool IsTeamMsg;

    public uint GetSize()
    {
        return 0; //Not needed
    }

    public void Serialize(Stream output)
    {
        //Not needed
    }
}