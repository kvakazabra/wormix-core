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
        throw new NotSupportedException();
    }

    public void Deserialize(Stream input)
    {
        BinaryReader br = new BinaryReader(input);
        PlayerNum = br.ReadByte();
        Action = (short)br.ReadUInt16Be();
        Message = br.ReadUTF8();
        BattleId = br.ReadUInt32Be();
        IsTeamMsg = br.ReadByte() != 0;
    }
}
