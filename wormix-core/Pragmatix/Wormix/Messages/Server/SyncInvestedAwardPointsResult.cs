using wormix_core.Extensions;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Wormix.Messages.Server;

public struct SyncInvestedAwardPointsResult() : ISerializable
{
    public byte Points;

    public uint GetSize()
    {
        return (uint)(
            // Points
            1
        );
    }

    public void Serialize(Stream output)
    {
        BinaryWriter bw = new BinaryWriter(output);
        bw.Write(Points);
    }

    public void Deserialize(Stream input)
    {
        throw new NotSupportedException();
    }
}
