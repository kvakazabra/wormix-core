using wormix_core.Extensions;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Wormix.Messages.Structures;

public struct BossWormStructure() : ISerializable
{
    public bool IsPlayerTeam = true;
    public int Hp;

    public uint GetSize()
    {
        return (uint)(
            // IsPlayerTeam
            1 +
            // Hp
            4
        );
    }

    public void Serialize(Stream output)
    {
        BinaryWriter bw = new BinaryWriter(output);
        bw.Write((byte)(IsPlayerTeam ? 1 : 0));
        bw.WriteUInt32Be((uint)Hp);
    }
}

