using wormix_core.Extensions;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Wormix.Messages.Structures;

public struct AbstractProfileStructure : ISerializable
{
    public uint Id;
    public string Name;
    public string SocialId;
    public int Money;
    public int RealMoney;
    public int Rating;
    public int ReactionRate;
    public int Rank;
    public int Skin;
    public ClanMemberStructure ClanMember;
    
    public uint GetSize()
    {
        return (uint)(
            // Id
            4 +
            // Name
            2 + System.Text.Encoding.UTF8.GetByteCount(Name) +
            // SocialId
            2 + System.Text.Encoding.UTF8.GetByteCount(SocialId) +
            // Money
            4 +
            // RealMoney
            4 +
            // Rating
            4 +
            // ReactionRate
            4 +
            // Rank
            4 +
            // Skin
            4 +
            // ClanMember flag
            2 +
            // ClanMember
            ClanMember.GetSize()
        );
    }

    public void Serialize(Stream output)
    {
        BinaryWriter bw = new BinaryWriter(output);
        bw.WriteUInt32Be(Id);
        bw.WriteUTF8(Name);
        bw.WriteUTF8(SocialId);
        bw.WriteUInt32Be((uint)Money);
        bw.WriteUInt32Be((uint)RealMoney);
        bw.WriteUInt32Be((uint)Rating);
        bw.WriteUInt32Be((uint)ReactionRate);
        bw.WriteUInt32Be((uint)Rank);
        bw.WriteUInt32Be((uint)Skin);
        bw.WriteUInt16Be(0);
        ClanMember.Serialize(output);
    }

    public void Deserialize(Stream input)
    {
        throw new NotSupportedException();
    }
}
