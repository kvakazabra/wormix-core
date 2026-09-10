using wormix_core.Extensions;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Wormix.Messages.Server;

public struct OpenChestResult() : ISerializable
{
    public short EquipId;
    public int WeaponId;
    public int WeaponCount;
    public int FuzyCount;
    public int RubyCount;
    public short RecipeId;
    public short Result;
    public string SessionKey = "";
    public int MedalCount;
    public int MutagenCount;
    public int Experience;
    public int Battles;
    public int BossToken;
    public int WagerToken;

    public uint GetSize()
    {
        return (uint)(
            // EquipId
            2 +
            // WeaponId
            4 +
            // WeaponCount
            4 +
            // FuzyCount
            4 +
            // RubyCount
            4 +
            // RecipeId
            2 +
            // Result
            2 +
            // SessionKey
            2 + System.Text.Encoding.UTF8.GetByteCount(SessionKey) +
            // MedalCount
            4 +
            // MutagenCount
            4 +
            // Experience
            4 +
            // Battles
            4 +
            4 +
            4
        );
    }

    public void Serialize(Stream output)
    {
        BinaryWriter bw = new BinaryWriter(output);

        bw.WriteUInt16Be((ushort)EquipId);
        bw.WriteUInt32Be((uint)WeaponId);
        bw.WriteUInt32Be((uint)WeaponCount);
        bw.WriteUInt32Be((uint)FuzyCount);
        bw.WriteUInt32Be((uint)RubyCount);
        bw.WriteUInt16Be((ushort)RecipeId);
        bw.WriteUInt16Be((ushort)Result);
        bw.WriteUTF8(SessionKey);
        bw.WriteUInt32Be((uint)MedalCount);
        bw.WriteUInt32Be((uint)MutagenCount);
        bw.WriteUInt32Be((uint)Experience);
        bw.WriteUInt32Be((uint)Battles);
        bw.WriteUInt32Be((uint)BossToken);
        bw.WriteUInt32Be((uint)WagerToken);
    }
}

