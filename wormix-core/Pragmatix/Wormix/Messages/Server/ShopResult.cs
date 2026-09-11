using wormix_core.Extensions;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;
using wormix_core.Pragmatix.Wormix.Messages.Structures;

namespace wormix_core.Pragmatix.Wormix.Messages.Server;

public struct ShopResult() : ISerializable
{
    public short Result;
    public List<WeaponStructure> Weapons = new();
    public List<short> Stuff = new();
    public List<TemporalStuffStructure> TemporalStuff = new();

    public uint GetSize()
    {
        return (uint)(
            // Result
            2 +
            // Weapons[]
            2 + Weapons.Sum((x) => x.GetSize() + 2) +
            // Stuff[]
            2 + 2 * Stuff.Count +
            // TemporalStuff[]
            2 + TemporalStuff.Sum((x) => x.GetSize() + 2)
        );
    }

    public void Serialize(Stream output)
    {
        BinaryWriter bw = new BinaryWriter(output);
        bw.WriteUInt16Be((ushort)Result);

        bw.WriteUInt16Be((ushort)Weapons.Count);
        Weapons.ForEach((x) =>
        {
            bw.WriteUInt16Be((ushort)x.GetSize());
            x.Serialize(output);
        });

        bw.WriteUInt16Be((ushort)Stuff.Count);
        Stuff.ForEach((x) => bw.WriteUInt16Be((ushort)x));

        bw.WriteUInt16Be((ushort)TemporalStuff.Count);
        TemporalStuff.ForEach((x) =>
        {
            bw.WriteUInt16Be((ushort)x.GetSize());
            x.Serialize(output);
        });
    }

    public void Deserialize(Stream input)
    {
        throw new NotSupportedException();
    }
}
