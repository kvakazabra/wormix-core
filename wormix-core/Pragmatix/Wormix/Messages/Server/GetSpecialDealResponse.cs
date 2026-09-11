using wormix_core.Extensions;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Wormix.Messages.Server;

public struct GetSpecialDealResponse() : ISerializable
{
    public short WeaponId;
    public byte RubyPrice;

    public uint GetSize()
    {
        return (uint)(
            // WeaponId
            2 +
            // RubyPrice
            1
        );
    }

    public void Serialize(Stream output)
    {
        BinaryWriter bw = new BinaryWriter(output);

        bw.WriteUInt16Be((ushort)WeaponId);
        bw.Write(RubyPrice);
    }

    public void Deserialize(Stream input)
    {
        throw new NotSupportedException();
    }
}
