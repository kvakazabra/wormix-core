using wormix_core.Extensions;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;
using wormix_core.Pragmatix.Wormix.Messages.Structures;

namespace wormix_core.Pragmatix.Wormix.Messages.Server;

public struct ProfileExtraInfoResponse() : ISerializable
{
    public int ProfileId;
    public short Races;
    public List<byte> Skins = new();
    public List<int> Reagents = new();
    public List<UnluckyCraftCount> UnluckyCraftCounts = new();
    public List<BackpackConfStructure> BackpackConfs = new();
    public byte ActiveBackpackConf;

    public uint GetSize()
    {
        return (uint)(
            // ProfileId
            4 +
            // Races
            2 +
            // Skins
            2 + Skins.Count +
            // Reagents
            2 + 4 * Reagents.Count +
            // UnluckyCraftCounts
            2 + UnluckyCraftCounts.Sum((x) => 2 + x.GetSize()) +
            // BackpackConfs
            2 + BackpackConfs.Sum((x) => 2 + x.GetSize()) +
            // ActiveBackpackConf
            1
        );
    }

    public void Serialize(Stream output)
    {
        BinaryWriter bw = new BinaryWriter(output);

        bw.WriteUInt32Be((uint)ProfileId);
        bw.WriteUInt16Be((ushort)Races);

        bw.WriteUInt16Be((ushort)Skins.Count);
        Skins.ForEach((x) => bw.Write(x));

        bw.WriteUInt16Be((ushort)Reagents.Count);
        Reagents.ForEach((x) => bw.WriteUInt32Be((uint)x));

        bw.WriteUInt16Be((ushort)UnluckyCraftCounts.Count);
        UnluckyCraftCounts.ForEach((x) =>
        {
            bw.WriteUInt16Be((ushort)x.GetSize());
            x.Serialize(output);
        });

        bw.WriteUInt16Be((ushort)BackpackConfs.Count);
        BackpackConfs.ForEach((x) =>
        {
            bw.WriteUInt16Be((ushort)x.GetSize());
            x.Serialize(output);
        });

        bw.Write(ActiveBackpackConf);
    }
}

