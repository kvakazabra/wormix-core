using wormix_core.Extensions;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Wormix.Messages.Structures;

public struct ClanInviteStructure() : ISerializable
{
    public int ClanId;
    public string ClanName = "";
    public List<byte> ClanEmblem = new();
    public int SocialId;
    public uint ProfileId;
    public string StringProfileId = "";
    public int Rank;
    public string Name = "";
    public int InviteDate;

    public uint GetSize()
    {
        return (uint)(
            // ClanId
            4 +
            // ClanName
            2 + System.Text.Encoding.UTF8.GetByteCount(ClanName) +
            // ClanEmblem
            2 + ClanEmblem.Count +
            // SocialId
            2 +
            // ProfileId
            4 +
            // StringProfileId
            2 + System.Text.Encoding.UTF8.GetByteCount(StringProfileId) +
            // Rank
            2 +
            // Name
            2 + System.Text.Encoding.UTF8.GetByteCount(Name) +
            // InviteDate
            4
        );
    }

    public void Serialize(Stream output)
    {
        BinaryWriter bw = new BinaryWriter(output);
        bw.WriteUInt32Be((uint)ClanId);
        bw.WriteUTF8(ClanName);

        bw.WriteUInt16Be((ushort)ClanEmblem.Count);
        ClanEmblem.ForEach((x) => bw.Write(x));

        bw.WriteUInt16Be((ushort)SocialId);
        bw.WriteUInt32Be(ProfileId);
        bw.WriteUTF8(StringProfileId);

        bw.WriteUInt16Be((ushort)Rank);
        bw.WriteUTF8(Name);
        bw.WriteUInt32Be((uint)InviteDate);
    }

    public void Deserialize(Stream input)
    {
        BinaryReader br = new BinaryReader(input);
        ClanId = (int)br.ReadUInt32Be();
        ClanName = br.ReadUTF8();
        ushort emblemLength = br.ReadUInt16Be();
        ClanEmblem = new List<byte>();
        for (int i = 0; i < emblemLength; i++)
            ClanEmblem.Add(br.ReadByte());
        SocialId = (int)br.ReadUInt16Be();
        ProfileId = br.ReadUInt32Be();
        StringProfileId = br.ReadUTF8();
        Rank = (int)br.ReadUInt16Be();
        Name = br.ReadUTF8();
        InviteDate = (int)br.ReadUInt32Be();
    }
}
