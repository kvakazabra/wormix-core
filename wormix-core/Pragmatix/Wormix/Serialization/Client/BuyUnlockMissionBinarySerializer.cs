using wormix_core.Extensions;
using wormix_core.Pragmatix.Flox.Serialization.Interfaces;
using wormix_core.Pragmatix.Wormix.Messages.Client;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Wormix.Serialization.Client;

public class BuyUnlockMissionBinarySerializer : ICommandSerializer
{
    public uint GetCommandId()
    {
        return 58;
    }

    public void SerializeCommand(ISerializable command, Stream output)
    {
        //Not needed
    }

    public ISerializable DeserializeCommand(Stream input, ICommandHeader header)
    {
        BuyUnlockMission msg = new();

        BinaryReader br = new BinaryReader(input);
        msg.MissionId = (short)br.ReadUInt16Be();

        return msg;
    }
}
