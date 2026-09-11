using wormix_core.Extensions;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Wormix.Messages.Server;

public struct NeedMoneyResult() : ISerializable
{
    public int Value;
    public short Result;

    public uint GetSize()
    {
        return (uint)(
            // Value
            4 +
            // Result
            2
        );
    }

    public void Serialize(Stream output)
    {
        BinaryWriter bw = new BinaryWriter(output);

        bw.WriteUInt32Be((uint)Value);
        bw.WriteUInt16Be((ushort)Result);
    }

    public void Deserialize(Stream input)
    {
        throw new NotSupportedException();
    }
}
