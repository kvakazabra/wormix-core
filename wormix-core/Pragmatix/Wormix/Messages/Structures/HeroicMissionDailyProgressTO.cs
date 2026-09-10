using wormix_core.Extensions;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Wormix.Messages.Structures;

public struct HeroicMissionDailyProgressTO : ISerializable
{
    public int DefeatCount;
    public int WinCount;

    public uint GetSize()
    {
        return (uint)(
            // DefeatCount
            4 +
            // WinCount
            4
        );
    }

    public void Serialize(Stream output)
    {
        BinaryWriter bw = new BinaryWriter(output);
        bw.WriteUInt32Be((uint)DefeatCount);
        bw.WriteUInt32Be((uint)WinCount);
    }
}

