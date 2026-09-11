using wormix_core.Extensions;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Wormix.Messages.Server;

public struct ChooseBonusItemResult() : ISerializable
{
    public short Result;
    public int ItemId;
    public bool IsSecure;

    public uint GetSize()
    {
        return (uint)(
            // Result
            2 +
            // ItemId
            4
        );
    }

    public void Serialize(Stream output)
    {
        BinaryWriter bw = new BinaryWriter(output);
        bw.WriteUInt16Be((ushort)Result);
        bw.WriteUInt32Be((uint)ItemId);
    }

    public void Deserialize(Stream input)
    {
        throw new NotSupportedException();
    }
}
