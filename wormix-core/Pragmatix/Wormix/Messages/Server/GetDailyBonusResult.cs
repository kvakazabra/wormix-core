using wormix_core.Extensions;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;
using wormix_core.Pragmatix.Wormix.Messages.Structures;

namespace wormix_core.Pragmatix.Wormix.Messages.Server;

public struct GetDailyBonusResult() : ISerializable
{
    public short Result;
    public List<GenericAwardStructure> Awards = new();

    public uint GetSize()
    {
        return (uint)(
            // Result
            2 +
            // Awards
            2 + Awards.Sum((x) => 2 + x.GetSize())
        );
    }

    public void Serialize(Stream output)
    {
        BinaryWriter bw = new BinaryWriter(output);

        bw.WriteUInt16Be((ushort)Result);

        bw.WriteUInt16Be((ushort)Awards.Count);
        Awards.ForEach((x) =>
        {
            bw.WriteUInt16Be((ushort)x.GetSize());
            x.Serialize(output);
        });
    }
}

