using wormix_core.Extensions;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Wormix.Messages.Client;

public struct SearchTheHouse() : ISerializable
{
    public string SessionKey = "";
    public uint FriendId;
    public byte KeyNum;

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
        SessionKey = br.ReadUTF8();
        FriendId = br.ReadUInt32Be();
        KeyNum = br.ReadByte();
    }
}
