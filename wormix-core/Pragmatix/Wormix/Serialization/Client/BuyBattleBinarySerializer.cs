using wormix_core.Extensions;
using wormix_core.Pragmatix.Flox.Serialization.Interfaces;
using wormix_core.Pragmatix.Wormix.Messages.Client;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Wormix.Serialization.Client;

public class BuyBattleBinarySerializer : ICommandSerializer
{
    public uint GetCommandId()
    {
        return 11;
    }

    public void SerializeCommand(ISerializable command, Stream output)
    {
        //Not needed
    }

    public ISerializable DeserializeCommand(Stream input, ICommandHeader header)
    {
        BuyBattle msg = new();

        BinaryReader br = new BinaryReader(input);
        msg.MoneyType = (int)br.ReadUInt32Be();
        msg.Bulk = br.ReadByte() != 0;

        return msg;
    }
}
