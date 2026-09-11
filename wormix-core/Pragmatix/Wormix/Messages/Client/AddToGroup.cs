using wormix_core.Extensions;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Wormix.Messages.Client;

public struct AddToGroup() : ISerializable
{
    public int ProfileId;
    public short MoneyType;
    public short TeamMemberType;
    public int ReplaceableId;
    public bool Active;

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
        ProfileId = (int)br.ReadUInt32Be();
        MoneyType = (short)br.ReadUInt16Be();
        TeamMemberType = (short)br.ReadUInt16Be();
        ReplaceableId = (int)br.ReadUInt32Be();
        Active = br.ReadByte() != 0;
    }
}
