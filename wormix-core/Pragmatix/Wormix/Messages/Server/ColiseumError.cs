using wormix_core.Extensions;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Wormix.Messages.Server;

public struct ColiseumError() : ISerializable
{
    public int Code;

    public uint GetSize()
    {
        return (uint)(
            // Code
            4
        );
    }

    public void Serialize(Stream output)
    {
        BinaryWriter bw = new BinaryWriter(output);
        bw.WriteUInt32Be((uint)Code);
    }

    public void Deserialize(Stream input)
    {
        throw new NotSupportedException();
    }
}
