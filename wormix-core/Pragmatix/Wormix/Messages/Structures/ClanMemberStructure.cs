using wormix_core.Extensions;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Wormix.Messages.Structures;

public struct ClanMemberStructure() : ISerializable
{
    public int Rank;
    public int ClanId;
    public string ClanName;
    public List<byte> ClanEmblem = new();
    public int ClanRating;
    public int ClanSeasonRating;
    public int ReviewState;
    public int PrevSeasonTopPlace;
    
    public uint GetSize()
    {
        return (uint)(
            // Rank
            2 +
            // ClanId
            4 +
            // ClanName
            2 + System.Text.Encoding.UTF8.GetByteCount(ClanName) +
            // ClanEmblemLength
            2 +
            // ClanEmblem[]
            ClanEmblem.Count +
            // ClanRating
            4 +
            // ClanSeasonRating
            4 +
            // ReviewState
            2 +
            // PrevSeasonTopPlace
            4
        );
    }

    public void Serialize(Stream output)
    {
        BinaryWriter bw = new BinaryWriter(output);
        bw.WriteUInt16Be((ushort)Rank);
        bw.WriteUInt32Be((uint)ClanId);
        bw.WriteUTF8(ClanName);
        bw.WriteUInt16Be((ushort)ClanEmblem.Count);
        ClanEmblem.ForEach((e) => bw.Write(e));
        bw.WriteUInt32Be((uint)ClanRating);
        bw.WriteUInt32Be((uint)ClanSeasonRating);
        bw.WriteUInt16Be((ushort)ReviewState);
        bw.WriteUInt32Be((uint)PrevSeasonTopPlace);
    }

    public void Deserialize(Stream input)
    {
        BinaryReader br = new BinaryReader(input);
        Rank = (int)br.ReadUInt16Be();
        ClanId = (int)br.ReadUInt32Be();
        ClanName = br.ReadUTF8();
        ushort emblemLength = br.ReadUInt16Be();
        ClanEmblem = new List<byte>();
        for (int i = 0; i < emblemLength; i++)
            ClanEmblem.Add(br.ReadByte());
        ClanRating = (int)br.ReadUInt32Be();
        ClanSeasonRating = (int)br.ReadUInt32Be();
        ReviewState = (int)br.ReadUInt16Be();
        PrevSeasonTopPlace = (int)br.ReadUInt32Be();
    }
}
