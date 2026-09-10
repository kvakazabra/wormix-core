using wormix_core.Extensions;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Wormix.Messages.Structures;

public struct QuestProgressStructure : ISerializable
{
    public int QuestId;
    public bool CanStartNew;
    public string Progress;
    public bool Rewarded;

    public uint GetSize()
    {
        return (uint)(
            // QuestId
            4 +
            // CanStartNew
            1 +
            // Progress
            2 + System.Text.Encoding.UTF8.GetByteCount(Progress) +
            // Rewarded
            1
        );
    }

    public void Serialize(Stream output)
    {
        BinaryWriter bw = new BinaryWriter(output);
        bw.WriteUInt32Be((uint)QuestId);
        bw.Write((byte)(CanStartNew ? 1 : 0));
        bw.WriteUTF8(Progress);
        bw.Write((byte)(Rewarded ? 1 : 0));
    }
}

