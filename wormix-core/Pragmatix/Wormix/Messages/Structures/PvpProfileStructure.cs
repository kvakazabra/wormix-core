using wormix_core.Extensions;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Wormix.Messages.Structures;

public struct PvpProfileStructure() : ISerializable
{
    public uint Id;
    public int Money;
    public int RealMoney;
    public int Rating;
    public List<TeamMemberStructure> Units;
    public List<WeaponStructure> WeaponRecordList;
    public List<short> Stuff;
    public Dictionary<int, int> TemporalStuff = new();
    public int ReactionRate;
    public string SocialId;
    public List<short> Recipes = new();
    public ClanMemberStructure ClanMember;
    public int ExtraGroupSlotsCount;
    public int RankPoints;
    public int BestRank;
    public string PlayerNames;
    public int SocialNetworkId;
    public int PlayerNum;
    public int TeamNum;
    public int DailyRating;
    public List<short> BackpackConf;
    public List<TeamMemberStructure> ActiveTeamMembers;
    public List<byte> SeasonsBestRank;
    
    public uint GetSize()
    {
        return (uint)(
            // Id
            4 +
            // Money
            4 +
            // RealMoney
            4 +
            // Rating
            4 +
            // UnitsLength
            2 +
            // Units[]
            Units.Sum(u => 2 + u.GetSize()) +
            // WeaponRecordListLength
            2 +
            // WeaponRecordList[]
            WeaponRecordList.Sum(w => 4) +
            // StuffLength
            2 +
            // Stuff[]
            2 * Stuff.Count +
            // TemporalStuffLength
            2 +
            // TemporalStuff[]
            6 * TemporalStuff.Count +
            4 +
            // SocialId
            2 + System.Text.Encoding.UTF8.GetByteCount(SocialId) +
            2 +
            // Recipes
            2 * Recipes.Count +
            2 +
            // ClanMember
            ClanMember.GetSize() +
            1 +
            4 +
            1 +
            // PlayerNames
            2 + System.Text.Encoding.UTF8.GetByteCount(PlayerNames) +
            1 +
            1 +
            1 +
            4 +
            2 +
            // BackpackConf
            2 * BackpackConf.Count +
            2 +
            ActiveTeamMembers.Sum(x => 2 + x.GetSize()) +
            2 +
            // SeasonsBestRank
            SeasonsBestRank.Count
        );
    }

    public void Serialize(Stream output)
    {
        BinaryWriter bw = new BinaryWriter(output);
        bw.WriteUInt32Be(Id);
        bw.WriteUInt32Be((uint)Money);
        bw.WriteUInt32Be((uint)RealMoney);
        bw.WriteUInt32Be((uint)Rating);
        
        bw.WriteUInt16Be((ushort)Units.Count);
        Units.ForEach((u) =>
        {
            bw.WriteUInt16Be(0);
            u.Serialize(output);
        });
        
        bw.WriteUInt16Be((ushort)(WeaponRecordList.Count * 2));
        WeaponRecordList.ForEach((w) =>
        {
            bw.WriteUInt16Be((ushort)w.Id);
            bw.WriteUInt16Be((ushort)w.Count);
        });
        
        bw.WriteUInt16Be((ushort)Stuff.Count);
        Stuff.ForEach((s) => bw.WriteUInt16Be((ushort)s));
        
        bw.WriteUInt16Be((ushort)TemporalStuff.Count);
        foreach (var kvp in TemporalStuff)
        {
            bw.WriteUInt16Be((ushort)kvp.Key);
            bw.WriteUInt32Be((uint)kvp.Value);
        }
        
        bw.WriteUInt32Be((uint)ReactionRate);
        bw.WriteUTF8(SocialId);
        
        bw.WriteUInt16Be((ushort)Recipes.Count);
        Recipes.ForEach((r) => bw.WriteUInt16Be((ushort)r));
        
        bw.WriteUInt16Be(0);
        ClanMember.Serialize(output);
        bw.Write((byte)ExtraGroupSlotsCount);
        bw.WriteUInt32Be((uint)RankPoints);
        bw.Write((byte)BestRank);
        bw.WriteUTF8(PlayerNames);
        bw.Write((byte)SocialNetworkId);
        bw.Write((byte)PlayerNum);
        bw.Write((byte)TeamNum);
        bw.WriteUInt32Be((uint)DailyRating);
        
        bw.WriteUInt16Be((ushort)BackpackConf.Count);
        BackpackConf.ForEach((b) => bw.WriteUInt16Be((ushort)b));
        
        bw.WriteUInt16Be((ushort)ActiveTeamMembers.Count);
        ActiveTeamMembers.ForEach((x) =>
        {
            bw.WriteUInt16Be(0);
            x.Serialize(output);
        });
        
        bw.WriteUInt16Be((ushort)SeasonsBestRank.Count);
        SeasonsBestRank.ForEach((b) => bw.Write(b));
    }
}

