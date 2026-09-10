using wormix_core.Extensions;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Wormix.Messages.Server;

public struct RaceExceptExclusiveResult() : ISerializable
{
    public uint ProfileId;
    public short Race;
    public byte Skin;

    public uint GetSize()
    {
        return (uint)(
            // ProfileId
            4 +
            // Race
            2 +
            // Skin
            1
        );
    }

    public void Serialize(Stream output)
    {
        BinaryWriter bw = new BinaryWriter(output);
        bw.WriteUInt32Be(ProfileId);
        bw.WriteUInt16Be((ushort)Race);
        bw.Write(Skin);
    }
}

