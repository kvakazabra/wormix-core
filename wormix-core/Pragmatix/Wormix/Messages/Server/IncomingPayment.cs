using wormix_core.Extensions;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Wormix.Messages.Server;

public struct IncomingPayment() : ISerializable
{
    public short PaymentType;
    public string Item = "";
    public int Count;
    public string Note = "";
    public string SessionKey = "";

    public uint GetSize()
    {
        return (uint)(
            // PaymentType
            2 +
            // Item
            2 + System.Text.Encoding.UTF8.GetByteCount(Item) +
            // Count
            4 +
            // Note
            2 + System.Text.Encoding.UTF8.GetByteCount(Note) +
            // SessionKey
            2 + System.Text.Encoding.UTF8.GetByteCount(SessionKey)
        );
    }

    public void Serialize(Stream output)
    {
        BinaryWriter bw = new BinaryWriter(output);

        bw.WriteUInt16Be((ushort)PaymentType);
        bw.WriteUTF8(Item);
        bw.WriteUInt32Be((uint)Count);
        bw.WriteUTF8(Note);
        bw.WriteUTF8(SessionKey);
    }

    public void Deserialize(Stream input)
    {
        throw new NotSupportedException();
    }
}
