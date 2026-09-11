using wormix_core.Extensions;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Wormix.Messages.Structures;

public struct BossBattleAwardStructure : ISerializable
{
    public int Id;
    public BossBattleWinAwardStructure FirstWinBattleAward;
    public BossBattleWinAwardStructure NextWinBattleAward;

    public uint GetSize()
    {
        return (uint)(
            // Id
            4 +
            // flag
            2 +
            // FirstWinBattleAward
            FirstWinBattleAward.GetSize() +
            // flag
            2 +
            // NextWinBattleAward
            NextWinBattleAward.GetSize()
        );
    }

    public void Serialize(Stream output)
    {
        BinaryWriter bw = new BinaryWriter(output);
        bw.WriteUInt32Be((uint)Id);
        bw.WriteUInt16Be(0);
        FirstWinBattleAward.Serialize(output);
        bw.WriteUInt16Be(0);
        NextWinBattleAward.Serialize(output);
    }

    public void Deserialize(Stream input)
    {
        BinaryReader br = new BinaryReader(input);
        Id = (int)br.ReadUInt32Be();
        br.ReadUInt16Be();
        FirstWinBattleAward.Deserialize(input);
        br.ReadUInt16Be();
        NextWinBattleAward.Deserialize(input);
    }
}
