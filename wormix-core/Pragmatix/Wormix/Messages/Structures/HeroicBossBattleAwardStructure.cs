using wormix_core.Extensions;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Wormix.Messages.Structures;

public struct HeroicBossBattleAwardStructure() : ISerializable
{
    public int Level;
    public BossBattleWinAwardStructure WinAward;
    public List<int> WinReagentsAward = new();

    public uint GetSize()
    {
        return (uint)(
            // Level
            4 +
            // flag
            2 +
            // WinAward
            WinAward.GetSize() +
            // WinReagentsAward
            2 + WinReagentsAward.Count
        );
    }

    public void Serialize(Stream output)
    {
        BinaryWriter bw = new BinaryWriter(output);
        bw.WriteUInt32Be((uint)Level);
        bw.WriteUInt16Be(0);
        WinAward.Serialize(output);

        bw.WriteUInt16Be((ushort)WinReagentsAward.Count);
        WinReagentsAward.ForEach((x) => bw.Write((byte)x));
    }

    public void Deserialize(Stream input)
    {
        throw new NotSupportedException();
    }
}
