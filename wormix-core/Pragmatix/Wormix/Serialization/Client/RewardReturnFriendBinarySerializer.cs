using wormix_core.Extensions;
using wormix_core.Pragmatix.Flox.Serialization.Interfaces;
using wormix_core.Pragmatix.Wormix.Messages.Client;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Wormix.Serialization.Client;

public class RewardReturnFriendBinarySerializer : ICommandSerializer
{
    public uint GetCommandId()
    {
        return 92;
    }

    public void SerializeCommand(ISerializable command, Stream output)
    {
        //Not needed
    }

    public ISerializable DeserializeCommand(Stream input, ICommandHeader header)
    {
        RewardReturnFriend msg = new();

        BinaryReader br = new BinaryReader(input);
        msg.FriendId = br.ReadUInt32Be();

        return msg;
    }
}
