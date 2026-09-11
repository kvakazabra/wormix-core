using wormix_core.Extensions;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Wormix.Messages.Server;

public struct BuyGroupSlotResult() : ISerializable
{
    public short Result;
    public byte NewSlotsIndex;
    public string SessionKey = "";
    public bool IsSecure;

    public uint GetSize()
    {
        return (uint)(
            // Result
            2 +
            // NewSlotsIndex
            1 +
            // SessionKey
            2 + System.Text.Encoding.UTF8.GetByteCount(SessionKey)
        );
    }

    public void Serialize(Stream output)
    {
        BinaryWriter bw = new BinaryWriter(output);
        bw.WriteUInt16Be((ushort)Result);
        bw.Write(NewSlotsIndex);
        bw.WriteUTF8(SessionKey);
    }

    public void Deserialize(Stream input)
    {
        throw new NotSupportedException();
    }
}
