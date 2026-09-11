using wormix_core.Extensions;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;
using wormix_core.Pragmatix.Wormix.Messages.Structures;

namespace wormix_core.Pragmatix.Wormix.Messages.Server;

public struct WithdrawSeasonWeaponsResult() : ISerializable
{
    public List<WeaponStructure> WithdrawnWeapons = new();
    public int CompensationInMoney;
    public int CompensationInKeys;
    public List<int> PrevSeasonWeapons = new();
    public List<int> CurrentSeasonWeapons = new();
    public List<int> CurrentSeasonStuff = new();

    public uint GetSize()
    {
        return (uint)(
            // WithdrawnWeapons[]
            2 + WithdrawnWeapons.Sum((x) => x.GetSize() + 2) +
            // CompensationInMoney
            4 +
            // CompensationInKeys
            4 +
            // PrevSeasonWeapons[]
            2 + 4 * PrevSeasonWeapons.Count +
            // CurrentSeasonWeapons[]
            2 + 4 * CurrentSeasonWeapons.Count +
            // CurrentSeasonStuff[]
            2 + 4 * CurrentSeasonStuff.Count
        );
    }

    public void Serialize(Stream output)
    {
        BinaryWriter bw = new BinaryWriter(output);
        bw.WriteUInt16Be((ushort)WithdrawnWeapons.Count);
        WithdrawnWeapons.ForEach((x) =>
        {
            bw.WriteUInt16Be((ushort)x.GetSize());
            x.Serialize(output);
        });

        bw.WriteUInt32Be((uint)CompensationInMoney);
        bw.WriteUInt32Be((uint)CompensationInKeys);

        bw.WriteUInt16Be((ushort)PrevSeasonWeapons.Count);
        PrevSeasonWeapons.ForEach((x) => bw.WriteUInt32Be((uint)x));

        bw.WriteUInt16Be((ushort)CurrentSeasonWeapons.Count);
        CurrentSeasonWeapons.ForEach((x) => bw.WriteUInt32Be((uint)x));

        bw.WriteUInt16Be((ushort)CurrentSeasonStuff.Count);
        CurrentSeasonStuff.ForEach((x) => bw.WriteUInt32Be((uint)x));
    }

    public void Deserialize(Stream input)
    {
        throw new NotSupportedException();
    }
}
