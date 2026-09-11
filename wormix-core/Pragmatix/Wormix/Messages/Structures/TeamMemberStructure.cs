using wormix_core.Extensions;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Wormix.Messages.Structures;

public struct TeamMemberStructure() : ISerializable
{
    public uint OwnerId;
    public int Armor;
    public int Attack;
    public int Level;
    public int Experience;
    public int HatId;
    public int RaceId;
    public int Skin;
    public int ArtifactId;
    public string SocialOwnerId;
    public string Name;
    public int TeamMemberType;
    public bool IsActive = true;
    
    public uint GetSize()
    {
        return (uint)(
            // OwnerId
            4 +
            // Armor
            1 +
            // Attack
            1 +
            // Level
            1 +
            // Experience
            4 +
            // HatId
            2 +
            // RaceId
            1 +
            // Skin
            1 +
            // ArtifactId
            2 +
            // SocialOwnerId
            2 + System.Text.Encoding.UTF8.GetByteCount(SocialOwnerId) +
            // Name
            2 + System.Text.Encoding.UTF8.GetByteCount(Name) +
            // TeamMemberType
            2 +
            1
        );
    }

    public void Serialize(Stream output)
    {
        BinaryWriter bw = new BinaryWriter(output);
        bw.WriteUInt32Be(OwnerId);
        bw.Write((byte)Armor);
        bw.Write((byte)Attack);
        bw.Write((byte)Level);
        bw.WriteUInt32Be((uint)Experience);
        bw.WriteUInt16Be((ushort)HatId);
        bw.Write((byte)RaceId);
        bw.Write((byte)Skin);
        bw.WriteUInt16Be((ushort)ArtifactId);
        bw.WriteUTF8(SocialOwnerId);
        bw.WriteUTF8(Name);
        bw.WriteUInt16Be((ushort)TeamMemberType);
        bw.Write((byte)(IsActive ? 1 : 0));
    }

    public void Deserialize(Stream input)
    {
        BinaryReader br = new BinaryReader(input);
        OwnerId = br.ReadUInt32Be();
        Armor = br.ReadByte();
        Attack = br.ReadByte();
        Level = br.ReadByte();
        Experience = (int)br.ReadUInt32Be();
        HatId = (int)br.ReadUInt16Be();
        RaceId = br.ReadByte();
        Skin = br.ReadByte();
        ArtifactId = (int)br.ReadUInt16Be();
        SocialOwnerId = br.ReadUTF8();
        Name = br.ReadUTF8();
        TeamMemberType = (int)br.ReadUInt16Be();
        IsActive = br.ReadByte() != 0;
    }
}
