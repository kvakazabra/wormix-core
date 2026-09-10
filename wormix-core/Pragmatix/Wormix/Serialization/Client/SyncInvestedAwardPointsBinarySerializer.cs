using wormix_core.Extensions;
using wormix_core.Pragmatix.Flox.Serialization.Interfaces;
using wormix_core.Pragmatix.Wormix.Messages.Client;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Wormix.Serialization.Client;

public class SyncInvestedAwardPointsBinarySerializer : ICommandSerializer
{
    public uint GetCommandId()
    {
        return 57;
    }

    public void SerializeCommand(ISerializable command, Stream output)
    {
        //Not needed
    }

    public ISerializable DeserializeCommand(Stream input, ICommandHeader header)
    {
        SyncInvestedAwardPoints msg = new();

        BinaryReader br = new BinaryReader(input);
        msg.SessionKey = br.ReadUTF8();

        return msg;
    }
}
