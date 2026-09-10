using wormix_core.Extensions;
using wormix_core.Pragmatix.Flox.Serialization.Interfaces;
using wormix_core.Pragmatix.Wormix.Messages.Client;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Wormix.Serialization.Client;

public class SendWipeConfirmCodeBinarySerializer : ICommandSerializer
{
    public uint GetCommandId()
    {
        return 52;
    }

    public void SerializeCommand(ISerializable command, Stream output)
    {
        //Not needed
    }

    public ISerializable DeserializeCommand(Stream input, ICommandHeader header)
    {
        SendWipeConfirmCode msg = new();

        BinaryReader br = new BinaryReader(input);
        msg.Level = (int)br.ReadUInt32Be();
        msg.Experience = (int)br.ReadUInt32Be();
        msg.Rating = (int)br.ReadUInt32Be();

        return msg;
    }
}
