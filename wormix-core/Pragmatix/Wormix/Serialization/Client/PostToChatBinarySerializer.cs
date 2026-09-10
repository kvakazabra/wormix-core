using wormix_core.Extensions;
using wormix_core.Pragmatix.Flox.Serialization.Interfaces;
using wormix_core.Pragmatix.Wormix.Messages.Client;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Wormix.Serialization.Client;

public class PostToChatBinarySerializer : ICommandSerializer
{
    public uint GetCommandId()
    {
        return 302;
    }

    public void SerializeCommand(ISerializable command, Stream output)
    {
        //Not needed
    }

    public ISerializable DeserializeCommand(Stream input, ICommandHeader header)
    {
        PostToChat msg = new();

        BinaryReader br = new BinaryReader(input);
        msg.Action = (short)br.ReadUInt16Be();
        msg.ProfileName = br.ReadUTF8();
        msg.Message = br.ReadUTF8();

        return msg;
    }
}
