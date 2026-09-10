using wormix_core.Extensions;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Wormix.Messages.Server;

public struct StartBattleResult() : ISerializable
{
    public uint BattleId;
    public List<byte> ReagentsForBattle = new();

    public uint GetSize()
    {
        return (uint)(
            // BattleId
            4 +
            // ReagentsForBattle[]
            2 + ReagentsForBattle.Count
        );
    }

    public void Serialize(Stream output)
    {
        BinaryWriter bw = new BinaryWriter(output);
        bw.WriteUInt32Be(BattleId);

        bw.WriteUInt16Be((ushort)ReagentsForBattle.Count);
        ReagentsForBattle.ForEach((x) => bw.Write(x));
    }
}

