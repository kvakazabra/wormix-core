using wormix_core.Extensions;
using wormix_core.Pragmatix.Flox.Serialization.Interfaces;
using wormix_core.Pragmatix.Wormix.Messages.Client;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Wormix.Serialization.Client;

public class BuyRaceBinarySerializer : ICommandSerializer
{
    public uint GetCommandId()
    {
        return 36;
    }

    public void SerializeCommand(ISerializable command, Stream output)
    {
        //Not needed
    }

    public ISerializable DeserializeCommand(Stream input, ICommandHeader header)
    {
        BuyRace msg = new();

        BinaryReader br = new BinaryReader(input);
        msg.RaceId = (short)br.ReadUInt16Be();
        msg.MoneyType = (short)br.ReadUInt16Be();

        return msg;
    }
}
