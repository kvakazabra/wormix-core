using wormix_core.Extensions;
using wormix_core.Pragmatix.Flox.Serialization.Interfaces;
using wormix_core.Pragmatix.Wormix.Messages.Client;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Wormix.Serialization.Client;

public class BuySelectRaceBinarySerializer : ICommandSerializer
{
    public uint GetCommandId()
    {
        return 50;
    }

    public void SerializeCommand(ISerializable command, Stream output)
    {
        //Not needed
    }

    public ISerializable DeserializeCommand(Stream input, ICommandHeader header)
    {
        BuySelectRace msg = new();

        BinaryReader br = new BinaryReader(input);
        msg.RaceId = (short)br.ReadUInt16Be();
        msg.SkinId = br.ReadByte();

        return msg;
    }
}
