using wormix_core.Extensions;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Wormix.Messages.Server;

public struct ArenaLocked() : ISerializable
{
    public uint Delay;
    public short CurrentMission;
    public short ErrorCode;

    public uint GetSize()
    {
        return (uint)(
            // Delay
            4 +
            // CurrentMission
            2 +
            // ErrorCode
            2
        );
    }

    public void Serialize(Stream output)
    {
        BinaryWriter bw = new BinaryWriter(output);
        bw.WriteUInt32Be(Delay);
        bw.WriteUInt16Be((ushort)CurrentMission);
        bw.WriteUInt16Be((ushort)ErrorCode);
    }
}

