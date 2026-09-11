using wormix_core.Extensions;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Wormix.Messages.Server;

public struct ActivatePromoKeyError() : ISerializable
{
    public string Key = "";

    public uint GetSize()
    {
        return (uint)(
            // Key
            2 + System.Text.Encoding.UTF8.GetByteCount(Key)
        );
    }

    public void Serialize(Stream output)
    {
        BinaryWriter bw = new BinaryWriter(output);
        bw.WriteUTF8(Key);
    }

    public void Deserialize(Stream input)
    {
        throw new NotSupportedException();
    }
}
