using wormix_core.Extensions;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Wormix.Messages.Server;

public struct UserIsBanned() : ISerializable
{
    public int Reason;
    public uint EndDate;
    public uint ProfileId;

    public uint GetSize()
    {
        return (uint)(
            // Reason
            4 +
            // EndDate
            4 +
            // ProfileId
            4
        );
    }

    public void Serialize(Stream output)
    {
        BinaryWriter bw = new BinaryWriter(output);
        bw.WriteUInt32Be((uint)Reason);
        bw.WriteUInt32Be(EndDate);
        bw.WriteUInt32Be(ProfileId);
    }
}

