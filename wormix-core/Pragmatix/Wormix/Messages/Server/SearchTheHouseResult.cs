using wormix_core.Extensions;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Wormix.Messages.Server;

public struct SearchTheHouseResult() : ISerializable
{
    public byte Result;
    public int Value;
    public byte AvailableSearchKeys;
    public uint FriendId;

    public uint GetSize()
    {
        return (uint)(
            // Result
            1 +
            // Value
            4 +
            // AvailableSearchKeys
            1 +
            // FriendId
            4
        );
    }

    public void Serialize(Stream output)
    {
        BinaryWriter bw = new BinaryWriter(output);
        bw.Write(Result);
        bw.WriteUInt32Be((uint)Value);
        bw.Write(AvailableSearchKeys);
        bw.WriteUInt32Be(FriendId);
    }
}

