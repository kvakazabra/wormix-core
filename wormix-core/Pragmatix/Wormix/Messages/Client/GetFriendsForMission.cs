using wormix_core.Extensions;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Wormix.Messages.Client;

public struct GetFriendsForMission() : ISerializable
{
    public List<short> BossIds = new();
    public short BattleWager;

    public uint GetSize()
    {
        return 0; //Not needed
    }

    public void Serialize(Stream output)
    {
        throw new NotSupportedException();
    }

    public void Deserialize(Stream input)
    {
        BinaryReader br = new BinaryReader(input);
        ushort n = br.ReadUInt16Be();
        for (int i = 0; i < n; i++)
            BossIds.Add((short)br.ReadUInt16Be());
        BattleWager = (short)br.ReadUInt16Be();
    }
}
