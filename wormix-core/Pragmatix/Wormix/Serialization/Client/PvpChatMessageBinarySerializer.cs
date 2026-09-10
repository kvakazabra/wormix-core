using wormix_core.Extensions;
using wormix_core.Pragmatix.Flox.Serialization.Interfaces;
using wormix_core.Pragmatix.Wormix.Messages.Client;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Wormix.Serialization.Client;

public class PvpChatMessageBinarySerializer : ICommandSerializer
{
    public uint GetCommandId()
    {
        return 17;
    }

    public void SerializeCommand(ISerializable command, Stream output)
    {
        //Not needed
    }

    public ISerializable DeserializeCommand(Stream input, ICommandHeader header)
    {
        PvpChatMessage msg = new();

        BinaryReader br = new BinaryReader(input);
        msg.PlayerNum = br.ReadByte();
        msg.Action = (short)br.ReadUInt16Be();
        msg.Message = br.ReadUTF8();
        msg.BattleId = br.ReadUInt32Be();
        msg.IsTeamMsg = br.ReadByte() != 0;

        return msg;
    }
}
