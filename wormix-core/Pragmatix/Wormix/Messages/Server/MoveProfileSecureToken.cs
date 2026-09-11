using wormix_core.Extensions;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Wormix.Messages.Server;

public struct MoveProfileSecureToken() : ISerializable
{
    public string SecureToken = "";
    public string SessionKey = "";

    public uint GetSize()
    {
        return (uint)(
            // SecureToken
            2 + System.Text.Encoding.UTF8.GetByteCount(SecureToken) +
            // SessionKey
            2 + System.Text.Encoding.UTF8.GetByteCount(SessionKey)
        );
    }

    public void Serialize(Stream output)
    {
        BinaryWriter bw = new BinaryWriter(output);

        bw.WriteUTF8(SecureToken);
        bw.WriteUTF8(SessionKey);
    }

    public void Deserialize(Stream input)
    {
        throw new NotSupportedException();
    }
}
