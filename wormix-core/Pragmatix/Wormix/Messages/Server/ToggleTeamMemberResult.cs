using wormix_core.Extensions;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Wormix.Messages.Server;

public struct ToggleTeamMemberResult() : ISerializable
{
    public short Result;
    public int TeamMemberId;

    public uint GetSize()
    {
        return (uint)(
            // Result
            2 +
            // TeamMemberId
            4
        );
    }

    public void Serialize(Stream output)
    {
        BinaryWriter bw = new BinaryWriter(output);
        bw.WriteUInt16Be((ushort)Result);
        bw.WriteUInt32Be((uint)TeamMemberId);
    }

    public void Deserialize(Stream input)
    {
        throw new NotSupportedException();
    }
}
