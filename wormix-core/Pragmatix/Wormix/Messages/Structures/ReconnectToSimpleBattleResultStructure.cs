using wormix_core.Extensions;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Wormix.Messages.Structures;

public struct ReconnectToSimpleBattleResultStructure : ISerializable
{
    public int BattleId;
    public int OriginalBattleId;
    public int MissionId;
    public int LastTurnNum;

    public uint GetSize()
    {
        return (uint)(
            // BattleId
            4 +
            // OriginalBattleId
            4 +
            // MissionId
            2 +
            // LastTurnNum
            2
        );
    }

    public void Serialize(Stream output)
    {
        BinaryWriter bw = new BinaryWriter(output);
        bw.WriteUInt32Be((uint)BattleId);
        bw.WriteUInt32Be((uint)OriginalBattleId);
        bw.WriteUInt16Be((ushort)MissionId);
        bw.WriteUInt16Be((ushort)LastTurnNum);
    }

    public void Deserialize(Stream input)
    {
        throw new NotSupportedException();
    }
}
