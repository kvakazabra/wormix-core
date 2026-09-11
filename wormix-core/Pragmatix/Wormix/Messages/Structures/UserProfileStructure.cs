using wormix_core.Extensions;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Wormix.Messages.Structures;

public struct UserProfileStructure() : ISerializable
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
            1
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
    }

    public void Deserialize(Stream input)
    {
        BinaryReader br = new BinaryReader(input);
        Id = br.ReadUInt32Be();
        Money = (int)br.ReadUInt32Be();
        RealMoney = (int)br.ReadUInt32Be();
        Rating = (int)br.ReadUInt32Be();

        Units = new List<TeamMemberStructure>();
        ushort unitsCount = br.ReadUInt16Be();
        for (int i = 0; i < unitsCount; i++)
        {
            br.ReadUInt16Be();
            TeamMemberStructure u = new TeamMemberStructure();
            u.Deserialize(input);
            Units.Add(u);
        }

        ushort weaponPairs = br.ReadUInt16Be();
        WeaponRecordList = new List<WeaponStructure>();
        for (int i = 0; i < weaponPairs; i++)
        {
            WeaponStructure w = new WeaponStructure();
            w.Id = br.ReadUInt16Be();
            w.Count = (short)br.ReadUInt16Be();
            WeaponRecordList.Add(w);
        }

        ushort stuffCount = br.ReadUInt16Be();
        Stuff = new List<short>();
        for (int i = 0; i < stuffCount; i++)
            Stuff.Add((short)br.ReadUInt16Be());

        ushort temporalCount = br.ReadUInt16Be();
        TemporalStuff = new Dictionary<int, int>();
        for (int i = 0; i < temporalCount; i++)
        {
            int key = (int)br.ReadUInt16Be();
            int value = (int)br.ReadUInt32Be();
            TemporalStuff[key] = value;
        }

        ReactionRate = (int)br.ReadUInt32Be();
        SocialId = br.ReadUTF8();

        ushort recipesCount = br.ReadUInt16Be();
        Recipes = new List<short>();
        for (int i = 0; i < recipesCount; i++)
            Recipes.Add((short)br.ReadUInt16Be());

        br.ReadUInt16Be();
        ClanMember.Deserialize(input);
        ExtraGroupSlotsCount = br.ReadByte();
        RankPoints = (int)br.ReadUInt32Be();
        BestRank = br.ReadByte();
    }
}
