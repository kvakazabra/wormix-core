using wormix_core.Extensions;
using wormix_core.Pragmatix.Flox.Serialization.Interfaces;
using wormix_core.Pragmatix.Wormix.Messages.Client;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Wormix.Serialization.Client;

public class GetFriendsForMissionBinarySerializer : ICommandSerializer
{
    public uint GetCommandId()
    {
        return 93;
    }

    public void SerializeCommand(ISerializable command, Stream output)
    {
        //Not needed
    }

    public ISerializable DeserializeCommand(Stream input, ICommandHeader header)
    {
        GetFriendsForMission msg = new();

        BinaryReader br = new BinaryReader(input);
        ushort n = br.ReadUInt16Be();
        for (int i = 0; i < n; i++)
            msg.BossIds.Add((short)br.ReadUInt16Be());
        msg.BattleWager = (short)br.ReadUInt16Be();

        return msg;
    }
}
