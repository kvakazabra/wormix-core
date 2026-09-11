using wormix_core.Extensions;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Wormix.Messages.Server;

public struct ShowSystemMessage() : ISerializable
{
    public string Msg = "";

    public uint GetSize()
    {
        return (uint)(
            // Msg
            2 + System.Text.Encoding.UTF8.GetByteCount(Msg)
        );
    }

    public void Serialize(Stream output)
    {
        BinaryWriter bw = new BinaryWriter(output);
        bw.WriteUTF8(Msg);
    }

    public void Deserialize(Stream input)
    {
        throw new NotSupportedException();
    }
}
