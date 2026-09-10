using wormix_core.Extensions;
using wormix_core.Pragmatix.Flox.Serialization.Interfaces;
using wormix_core.Pragmatix.Wormix.Messages.Client;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Wormix.Serialization.Client;

public class ExecuteSpecialDealBinarySerializer : ICommandSerializer
{
    public uint GetCommandId()
    {
        return 109;
    }

    public void SerializeCommand(ISerializable command, Stream output)
    {
        //Not needed
    }

    public ISerializable DeserializeCommand(Stream input, ICommandHeader header)
    {
        ExecuteSpecialDeal msg = new();

        BinaryReader br = new BinaryReader(input);
        msg.ItemId = (short)br.ReadUInt16Be();
        msg.RubyPrice = br.ReadByte();

        return msg;
    }
}
