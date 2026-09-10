using wormix_core.Extensions;
using wormix_core.Pragmatix.Flox.Serialization.Interfaces;
using wormix_core.Pragmatix.Wormix.Messages.Client;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;
using wormix_core.Pragmatix.Wormix.Messages.Structures;

namespace wormix_core.Pragmatix.Wormix.Serialization.Client;

public class SetBackpackConfBinarySerializer : ICommandSerializer
{
    public uint GetCommandId()
    {
        return 129;
    }

    public void SerializeCommand(ISerializable command, Stream output)
    {
        //Not needed
    }

    public ISerializable DeserializeCommand(Stream input, ICommandHeader header)
    {
        SetBackpackConf msg = new();

        BinaryReader br = new BinaryReader(input);
        ushort n = br.ReadUInt16Be();
        for (int i = 0; i < n; i++)
        {
            ushort size = br.ReadUInt16Be();
            BackpackConfStructure s = new();
            ushort count = br.ReadUInt16Be();
            s.Config = new List<short>();
            for (int j = 0; j < count; j++)
                s.Config.Add((short)br.ReadUInt16Be());
            msg.Configs.Add(s);
        }
        msg.ActiveConfig = br.ReadByte();

        return msg;
    }
}
