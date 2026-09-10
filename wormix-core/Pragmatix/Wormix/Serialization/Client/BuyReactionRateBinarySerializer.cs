using wormix_core.Extensions;
using wormix_core.Pragmatix.Flox.Serialization.Interfaces;
using wormix_core.Pragmatix.Wormix.Messages.Client;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Wormix.Serialization.Client;

public class BuyReactionRateBinarySerializer : ICommandSerializer
{
    public uint GetCommandId()
    {
        return 49;
    }

    public void SerializeCommand(ISerializable command, Stream output)
    {
        //Not needed
    }

    public ISerializable DeserializeCommand(Stream input, ICommandHeader header)
    {
        BuyReactionRate msg = new();

        BinaryReader br = new BinaryReader(input);
        msg.ReactionRateLevel = (int)br.ReadUInt32Be();

        return msg;
    }
}
