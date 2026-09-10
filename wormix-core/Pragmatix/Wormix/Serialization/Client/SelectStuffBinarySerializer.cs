using wormix_core.Extensions;
using wormix_core.Pragmatix.Flox.Serialization.Interfaces;
using wormix_core.Pragmatix.Wormix.Messages.Client;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;
using wormix_core.Pragmatix.Wormix.Messages.Structures;

namespace wormix_core.Pragmatix.Wormix.Serialization.Client;

public class SelectStuffBinarySerializer : ICommandSerializer
{
    public uint GetCommandId()
    {
        return 25;
    }

    public void SerializeCommand(ISerializable command, Stream output)
    {
        //Not needed
    }

    public ISerializable DeserializeCommand(Stream input, ICommandHeader header)
    {
        SelectStuff msg = new();

        BinaryReader br = new BinaryReader(input);
        ushort n = br.ReadUInt16Be();
        for (int i = 0; i < n; i++)
        {
            ushort size = br.ReadUInt16Be();
            SelectStuffStructure s = new();
            s.ProfileId = (int)br.ReadUInt32Be();
            s.HatId = (short)br.ReadUInt16Be();
            s.ArtifactId = (short)br.ReadUInt16Be();
            msg.SelectStuffs.Add(s);
        }

        return msg;
    }
}
