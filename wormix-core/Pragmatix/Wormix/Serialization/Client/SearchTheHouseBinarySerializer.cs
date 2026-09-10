using wormix_core.Extensions;
using wormix_core.Pragmatix.Flox.Serialization.Interfaces;
using wormix_core.Pragmatix.Wormix.Messages.Client;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Wormix.Serialization.Client;

public class SearchTheHouseBinarySerializer : ICommandSerializer
{
    public uint GetCommandId()
    {
        return 81;
    }

    public void SerializeCommand(ISerializable command, Stream output)
    {
        //Not needed
    }

    public ISerializable DeserializeCommand(Stream input, ICommandHeader header)
    {
        SearchTheHouse msg = new();

        BinaryReader br = new BinaryReader(input);
        msg.SessionKey = br.ReadUTF8();
        msg.FriendId = br.ReadUInt32Be();
        msg.KeyNum = br.ReadByte();

        return msg;
    }
}
