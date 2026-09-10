using wormix_core.Extensions;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Wormix.Messages.Server;

public struct BuyResetBonusItemsResult() : ISerializable
{
    public short Result;
    public int RequestNum;
    public bool IsSecure;

    public uint GetSize()
    {
        return (uint)(
            // Result
            2 +
            // RequestNum
            4
        );
    }

    public void Serialize(Stream output)
    {
        BinaryWriter bw = new BinaryWriter(output);
        bw.WriteUInt16Be((ushort)Result);
        bw.WriteUInt32Be((uint)RequestNum);
    }
}

