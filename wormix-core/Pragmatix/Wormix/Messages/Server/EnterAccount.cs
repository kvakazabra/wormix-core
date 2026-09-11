using wormix_core.Extensions;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;
using wormix_core.Pragmatix.Wormix.Messages.Structures;

namespace wormix_core.Pragmatix.Wormix.Messages.Server;

public struct EnterAccount() : ISerializable
{
    public UserProfileStructure UserProfileStructure = new();
    public List<UserProfileStructure> UserProfileStructures = new();
    public List<LoginAwardStructure> LoginAwards = new();
    public short OnlineFriends;
    public short Friends;
    public string SessionKey = "";
    public byte AvailableSearchKeys;
    public List<int> Reagents = new();
    public short CurSoloMissionId;
    public short CurCooperativeMissionId;
    public List<ClanInviteStructure> Invites = new();
    public int ServerTime;
    public List<BackpackConfStructure> BackpackConfs = new();
    public byte ActiveBackpackConf;
    public List<short> Hotkeys = new();
    public byte LoginSequence;
    public short Races;
    public int SelectRaceTimeLeft;
    public List<byte> Skins = new();
    public int LastPaymentTime;
    public List<RestrictionItemStructure> Restrictions = new();
    public Dictionary<string, string> Cookies = new();
    public int VipSubscriptionId;
    public bool HasReconnectResult;
    public ReconnectToSimpleBattleResultStructure ReconnectResult;

    public uint GetSize()
    {
        return (uint)(
            // UserProfileStructure size prefix
            2 +
            // UserProfileStructure
            UserProfileStructure.GetSize() +
            // UserProfileStructure[]
            2 + UserProfileStructures.Sum((x) => 2 + x.GetSize()) +
            // LoginAwardStructure[]
            2 + LoginAwards.Sum((x) => 2 + x.GetSize()) +
            // OnlineFriends
            2 +
            // Friends
            2 +
            // SessionKey
            2 + System.Text.Encoding.UTF8.GetByteCount(SessionKey) +
            // AvailableSearchKeys
            1 +
            // Reagents
            2 + 4 * Reagents.Count +
            // CurSoloMissionId
            2 +
            // CurCooperativeMissionId
            2 +
            // Invites
            2 + Invites.Sum((x) => 2 + x.GetSize()) +
            4 +
            // BackpackConfs[]
            2 + BackpackConfs.Sum((x) => 2 + x.GetSize()) +
            1 +
            // Hotkeys
            2 + 2 * Hotkeys.Count +
            1 +
            2 +
            4 +
            // Skins
            2 + Skins.Count +
            4 +
            // Restrictions[]
            2 + Restrictions.Sum((x) => 2 + x.GetSize()) +
            // Cookies[]
            2 + Cookies.Sum((x) => 2 + System.Text.Encoding.UTF8.GetByteCount(x.Key) + 2 + System.Text.Encoding.UTF8.GetByteCount(x.Value)) +
            4 +
            2 +
            // ReconnectResult
            (HasReconnectResult ? 2 + ReconnectResult.GetSize() : 0)
        );
    }

    public void Serialize(Stream output)
    {
        BinaryWriter bw = new BinaryWriter(output);

        bw.WriteUInt16Be((ushort)UserProfileStructure.GetSize());
        UserProfileStructure.Serialize(output);

        bw.WriteUInt16Be((ushort)UserProfileStructures.Count);
        UserProfileStructures.ForEach((x) =>
        {
            bw.WriteUInt16Be((ushort)x.GetSize());
            x.Serialize(output);
        });

        bw.WriteUInt16Be((ushort)LoginAwards.Count);
        LoginAwards.ForEach((x) =>
        {
            bw.WriteUInt16Be((ushort)x.GetSize());
            x.Serialize(output);
        });

        bw.WriteUInt16Be((ushort)OnlineFriends);
        bw.WriteUInt16Be((ushort)Friends);

        bw.WriteUTF8(SessionKey);

        bw.Write(AvailableSearchKeys);

        bw.WriteUInt16Be((ushort)Reagents.Count);
        Reagents.ForEach((x) => bw.WriteUInt32Be((uint)x));

        bw.WriteUInt16Be((ushort)CurSoloMissionId);
        bw.WriteUInt16Be((ushort)CurCooperativeMissionId);

        bw.WriteUInt16Be((ushort)Invites.Count);
        Invites.ForEach((x) =>
        {
            bw.WriteUInt16Be((ushort)x.GetSize());
            x.Serialize(output);
        });

        bw.WriteUInt32Be((uint)ServerTime);

        bw.WriteUInt16Be((ushort)BackpackConfs.Count);
        BackpackConfs.ForEach((x) =>
        {
            bw.WriteUInt16Be((ushort)x.GetSize());
            x.Serialize(output);
        });

        bw.Write(ActiveBackpackConf);

        bw.WriteUInt16Be((ushort)Hotkeys.Count);
        Hotkeys.ForEach((x) => bw.WriteUInt16Be((ushort)x));

        bw.Write(LoginSequence);

        bw.WriteUInt16Be((ushort)Races);

        bw.WriteUInt32Be((uint)SelectRaceTimeLeft);

        bw.WriteUInt16Be((ushort)Skins.Count);
        Skins.ForEach((x) => bw.Write(x));

        bw.WriteUInt32Be((uint)LastPaymentTime);

        bw.WriteUInt16Be((ushort)Restrictions.Count);
        Restrictions.ForEach((x) =>
        {
            bw.WriteUInt16Be((ushort)x.GetSize());
            x.Serialize(output);
        });

        bw.WriteUInt16Be((ushort)(Cookies.Count * 2));
        foreach (var pair in Cookies)
        {
            bw.WriteUTF8(pair.Key);
            bw.WriteUTF8(pair.Value);
        }

        bw.WriteUInt32Be((uint)VipSubscriptionId);

        bw.WriteUInt16Be((ushort)(HasReconnectResult ? 1 : 0));
        if (HasReconnectResult)
        {
            bw.WriteUInt16Be((ushort)ReconnectResult.GetSize());
            ReconnectResult.Serialize(output);
        }
    }

    public void Deserialize(Stream input)
    {
        throw new NotSupportedException();
    }
}
