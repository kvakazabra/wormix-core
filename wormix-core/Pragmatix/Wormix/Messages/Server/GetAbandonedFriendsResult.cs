using wormix_core.Extensions;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Wormix.Messages.Server;

public struct GetAbandonedFriendsResult() : ISerializable
{
    public List<uint> AbandonedFriendsPage = new();
    public List<string> AbandonedFriendsPageString = new();
    public int TotalAbandonedFriends;

    public uint GetSize()
    {
        return (uint)(
            // AbandonedFriendsPage
            2 + 4 * AbandonedFriendsPage.Count +
            // AbandonedFriendsPageString
            2 + AbandonedFriendsPageString.Sum((x) => 2 + System.Text.Encoding.UTF8.GetByteCount(x)) +
            // TotalAbandonedFriends
            4
        );
    }

    public void Serialize(Stream output)
    {
        BinaryWriter bw = new BinaryWriter(output);

        bw.WriteUInt16Be((ushort)AbandonedFriendsPage.Count);
        AbandonedFriendsPage.ForEach((x) => bw.WriteUInt32Be(x));

        bw.WriteUInt16Be((ushort)AbandonedFriendsPageString.Count);
        AbandonedFriendsPageString.ForEach((x) => bw.WriteUTF8(x));

        bw.WriteUInt32Be((uint)TotalAbandonedFriends);
    }
}

