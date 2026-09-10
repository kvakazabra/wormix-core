using wormix_core.Extensions;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Wormix.Messages.Server;

public struct BuyRenameCharResult() : ISerializable
{
    public short Result;
    public int TeamMemberId;
    public string Name = "";
    public string SessionKey = "";
    public bool IsSecure;

    public uint GetSize()
    {
        return (uint)(
            // Result
            2 +
            // TeamMemberId
            4 +
            // Name
            2 + System.Text.Encoding.UTF8.GetByteCount(Name) +
            // SessionKey
            2 + System.Text.Encoding.UTF8.GetByteCount(SessionKey)
        );
    }

    public void Serialize(Stream output)
    {
        BinaryWriter bw = new BinaryWriter(output);
        bw.WriteUInt16Be((ushort)Result);
        bw.WriteUInt32Be((uint)TeamMemberId);
        bw.WriteUTF8(Name);
        bw.WriteUTF8(SessionKey);
    }
}

