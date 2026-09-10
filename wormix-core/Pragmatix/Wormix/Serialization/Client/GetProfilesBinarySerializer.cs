using wormix_core.Extensions;
using wormix_core.Pragmatix.Flox.Serialization.Interfaces;
using wormix_core.Pragmatix.Wormix.Messages.Client;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Wormix.Serialization.Client;

public class GetProfilesBinarySerializer : ICommandSerializer
{
    public uint GetCommandId()
    {
        return 5;
    }

    public void SerializeCommand(ISerializable command, Stream output)
    {
        //Not needed
    }

    public ISerializable DeserializeCommand(Stream input, ICommandHeader header)
    {
        GetProfiles msg = new();

        BinaryReader br = new BinaryReader(input);
        msg.SessionKey = br.ReadUTF8();
        ushort n = br.ReadUInt16Be();
        for (int i = 0; i < n; i++)
            msg.Ids.Add(br.ReadUTF8());

        return msg;
    }
}
