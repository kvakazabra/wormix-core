using wormix_core.Extensions;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Wormix.Messages.Server;

public struct ExecuteSpecialDealResponse() : ISerializable
{
    public short Result;
    public short ItemId;
    public byte RubyPrice;
    public string SessionKey = "";

    public uint GetSize()
    {
        return (uint)(
            // Result
            2 +
            // ItemId
            2 +
            // RubyPrice
            1 +
            // SessionKey
            2 + System.Text.Encoding.UTF8.GetByteCount(SessionKey)
        );
    }

    public void Serialize(Stream output)
    {
        BinaryWriter bw = new BinaryWriter(output);

        bw.WriteUInt16Be((ushort)Result);
        bw.WriteUInt16Be((ushort)ItemId);
        bw.Write(RubyPrice);
        bw.WriteUTF8(SessionKey);
    }

    public void Deserialize(Stream input)
    {
        throw new NotSupportedException();
    }
}
