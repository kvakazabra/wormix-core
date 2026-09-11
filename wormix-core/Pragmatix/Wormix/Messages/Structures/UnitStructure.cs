using wormix_core.Extensions;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Wormix.Messages.Structures;

public struct UnitStructure : ISerializable
{
    public uint Id;
    public string Name;
    public int Armor;
    public int Attack;
    public int Level;
    public int Money;
    public int RealMoney;
    public int ReactionRate;
    public int Rating;
    public int GroupCount;
    public int HatId;
    public int RaceId;
    public int Skin;
    public int ArtifactId;
    public string SocialId;
    public ClanMemberStructure ClanMember;
    public int Rank;
    
    public uint GetSize()
    {
        return (uint)(
            // Id
            4 +
            // Name
            2 + System.Text.Encoding.UTF8.GetByteCount(Name) +
            // Armor
            4 +
            // Attack
            4 +
            // Level
            4 +
            // Money
            4 +
            // RealMoney
            4 +
            // ReactionRate
            4 +
            // Rating
            4 +
            // GroupCount
            4 +
            // HatId
            2 +
            // RaceId
            1 +
            1 +
            2 +
            // SocialId
            2 + System.Text.Encoding.UTF8.GetByteCount(SocialId) +
            2 +
            // ClanMember
            ClanMember.GetSize() +
            1
        );
    }

    public void Serialize(Stream output)
    {
        BinaryWriter bw = new BinaryWriter(output);
        bw.WriteUInt32Be(Id);
        bw.WriteUTF8(Name);
        bw.WriteUInt32Be((uint)Armor);
        bw.WriteUInt32Be((uint)Attack);
        bw.WriteUInt32Be((uint)Level);
        bw.WriteUInt32Be((uint)Money);
        bw.WriteUInt32Be((uint)RealMoney);
        bw.WriteUInt32Be((uint)ReactionRate);
        bw.WriteUInt32Be((uint)Rating);
        bw.WriteUInt32Be((uint)GroupCount);
        bw.WriteUInt16Be((ushort)HatId);
        bw.Write((byte)RaceId);
        bw.Write((byte)Skin);
        bw.WriteUInt16Be((ushort)ArtifactId);
        bw.WriteUTF8(SocialId);
        bw.WriteUInt16Be(0);
        ClanMember.Serialize(output);
        bw.Write((byte)Rank);
    }

    public void Deserialize(Stream input)
    {
        BinaryReader br = new BinaryReader(input);
        Id = br.ReadUInt32Be();
        Name = br.ReadUTF8();
        Armor = (int)br.ReadUInt32Be();
        Attack = (int)br.ReadUInt32Be();
        Level = (int)br.ReadUInt32Be();
        Money = (int)br.ReadUInt32Be();
        RealMoney = (int)br.ReadUInt32Be();
        ReactionRate = (int)br.ReadUInt32Be();
        Rating = (int)br.ReadUInt32Be();
        GroupCount = (int)br.ReadUInt32Be();
        HatId = (int)br.ReadUInt16Be();
        RaceId = br.ReadByte();
        Skin = br.ReadByte();
        ArtifactId = (int)br.ReadUInt16Be();
        SocialId = br.ReadUTF8();
        br.ReadUInt16Be();
        ClanMember.Deserialize(input);
        Rank = br.ReadByte();
    }
}
