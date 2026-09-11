using wormix_core.Extensions;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Wormix.Messages.Client;

public struct ReturnFriend() : ISerializable
{
    public uint FriendId;
    public string SessionKey = "";

    public uint GetSize()
    {
        return 0; //Not needed
    }

    public void Serialize(Stream output)
    {
        throw new NotSupportedException();
    }

    public void Deserialize(Stream input)
    {
        BinaryReader br = new BinaryReader(input);
        FriendId = br.ReadUInt32Be();
        SessionKey = br.ReadUTF8();
    }
}
