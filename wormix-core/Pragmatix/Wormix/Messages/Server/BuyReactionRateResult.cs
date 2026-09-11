using wormix_core.Extensions;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Wormix.Messages.Server;

public struct BuyReactionRateResult() : ISerializable
{
    public short Result;
    public int ReactionRateCount;
    public int ReactionRateLevel;

    public uint GetSize()
    {
        return (uint)(
            // Result
            2 +
            // ReactionRateCount
            4 +
            // ReactionRateLevel
            4
        );
    }

    public void Serialize(Stream output)
    {
        BinaryWriter bw = new BinaryWriter(output);
        bw.WriteUInt16Be((ushort)Result);
        bw.WriteUInt32Be((uint)ReactionRateCount);
        bw.WriteUInt32Be((uint)ReactionRateLevel);
    }

    public void Deserialize(Stream input)
    {
        throw new NotSupportedException();
    }
}
