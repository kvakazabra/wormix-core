using wormix_core.Extensions;
using wormix_core.Pragmatix.Flox.Serialization.Interfaces;
using wormix_core.Pragmatix.Wormix.Messages.Client;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Wormix.Serialization.Client;

public class ToggleTeamMemberBinarySerializer : ICommandSerializer
{
    public uint GetCommandId()
    {
        return 106;
    }

    public void SerializeCommand(ISerializable command, Stream output)
    {
        //Not needed
    }

    public ISerializable DeserializeCommand(Stream input, ICommandHeader header)
    {
        ToggleTeamMember msg = new();

        BinaryReader br = new BinaryReader(input);
        msg.TeamMemberId = (int)br.ReadUInt32Be();
        msg.Active = br.ReadByte() != 0;

        return msg;
    }
}
