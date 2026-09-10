using wormix_core.Extensions;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Wormix.Messages.Server;

public struct SelectRaceResult() : ISerializable
{
    public short Result;
    public short Race;
    public byte Skin;

    public uint GetSize()
    {
        return (uint)(
            // Result
            2 +
            // Race
            2 +
            // Skin
            1
        );
    }

    public void Serialize(Stream output)
    {
        BinaryWriter bw = new BinaryWriter(output);
        bw.WriteUInt16Be((ushort)Result);
        bw.WriteUInt16Be((ushort)Race);
        bw.Write(Skin);
    }
}

