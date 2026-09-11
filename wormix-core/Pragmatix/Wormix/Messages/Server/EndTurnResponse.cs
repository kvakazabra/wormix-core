using wormix_core.Extensions;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Wormix.Messages.Server;

public struct EndTurnResponse() : ISerializable
{
    public short Result;
    public uint BattleId;
    public short TurnNum;
    public short LastTurnNum;

    public uint GetSize()
    {
        return (uint)(
            // Result
            2 +
            // BattleId
            4 +
            // TurnNum
            2 +
            // LastTurnNum
            2
        );
    }

    public void Serialize(Stream output)
    {
        BinaryWriter bw = new BinaryWriter(output);
        bw.WriteUInt16Be((ushort)Result);
        bw.WriteUInt32Be(BattleId);
        bw.WriteUInt16Be((ushort)TurnNum);
        bw.WriteUInt16Be((ushort)LastTurnNum);
    }

    public void Deserialize(Stream input)
    {
        throw new NotSupportedException();
    }
}
