using wormix_core.Extensions;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Wormix.Messages.Server;

public struct AwardedFriendsComeback() : ISerializable
{
    public List<uint> FriendsId = new();
    public List<string> FriendsIdString = new();

    public uint GetSize()
    {
        return (uint)(
            // FriendsId
            2 + 4 * FriendsId.Count +
            // FriendsIdString
            2 + FriendsIdString.Sum((x) => System.Text.Encoding.UTF8.GetByteCount(x) + 2)
        );
    }

    public void Serialize(Stream output)
    {
        BinaryWriter bw = new BinaryWriter(output);
        bw.WriteUInt16Be((ushort)FriendsId.Count);
        FriendsId.ForEach((x) => bw.WriteUInt32Be(x));

        bw.WriteUInt16Be((ushort)FriendsIdString.Count);
        FriendsIdString.ForEach((x) => bw.WriteUTF8(x));
    }

    public void Deserialize(Stream input)
    {
        throw new NotSupportedException();
    }
}
