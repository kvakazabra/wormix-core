using wormix_core.Extensions;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Wormix.Messages.Client;

public struct GetRating() : ISerializable
{
    public short RatingType;
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
        RatingType = (short)br.ReadUInt16Be();
        BattleWager = (short)br.ReadUInt16Be();
    }
}
