using wormix_core.Extensions;
using wormix_core.Pragmatix.Flox.Serialization.Interfaces;
using wormix_core.Pragmatix.Wormix.Messages.Client;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Wormix.Serialization.Client;

public class RegenerateCandidatesBinarySerializer : ICommandSerializer
{
    public uint GetCommandId()
    {
        return 113;
    }

    public void SerializeCommand(ISerializable command, Stream output)
    {
        //Not needed
    }

    public ISerializable DeserializeCommand(Stream input, ICommandHeader header)
    {
        RegenerateCandidates msg = new();

        BinaryReader br = new BinaryReader(input);
        msg.AllTeam = br.ReadByte() != 0;

        return msg;
    }
}
