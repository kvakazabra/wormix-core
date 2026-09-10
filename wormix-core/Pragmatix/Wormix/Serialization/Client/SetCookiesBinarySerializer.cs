using wormix_core.Extensions;
using wormix_core.Pragmatix.Flox.Serialization.Interfaces;
using wormix_core.Pragmatix.Wormix.Messages.Client;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Wormix.Serialization.Client;

public class SetCookiesBinarySerializer : ICommandSerializer
{
    public uint GetCommandId()
    {
        return 136;
    }

    public void SerializeCommand(ISerializable command, Stream output)
    {
        //Not needed
    }

    public ISerializable DeserializeCommand(Stream input, ICommandHeader header)
    {
        SetCookies msg = new();

        BinaryReader br = new BinaryReader(input);
        ushort n1 = br.ReadUInt16Be();
        for (int i = 0; i < n1; i++)
            msg.Names.Add(br.ReadUTF8());
        ushort n2 = br.ReadUInt16Be();
        for (int i = 0; i < n2; i++)
            msg.Values.Add(br.ReadUTF8());

        return msg;
    }
}
