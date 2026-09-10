using wormix_core.Extensions;
using wormix_core.Pragmatix.Flox.Serialization.Interfaces;
using wormix_core.Pragmatix.Wormix.Messages.Client;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Wormix.Serialization.Client;

public class GetVipSubscriptionBinarySerializer : ICommandSerializer
{
    public uint GetCommandId()
    {
        return 140;
    }

    public void SerializeCommand(ISerializable command, Stream output)
    {
        //Not needed
    }

    public ISerializable DeserializeCommand(Stream input, ICommandHeader header)
    {
        GetVipSubscription msg = new();

        BinaryReader br = new BinaryReader(input);
        msg.VipSubscriptionId = (int)br.ReadUInt32Be();

        return msg;
    }
}
