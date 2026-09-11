using wormix_core.Extensions;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Wormix.Messages.Structures;

public struct AwardBackpackItemStructure : ISerializable
{
    public int WeaponId;
    public int Count;
    public int StuffId;
    public int ExpireHours;

    public uint GetSize()
    {
        return (uint)(
            // WeaponId
            4 +
            // Count
            4 +
            // StuffId
            4 +
            // ExpireHours
            4
        );
    }

    public void Serialize(Stream output)
    {
        BinaryWriter bw = new BinaryWriter(output);
        bw.WriteUInt32Be((uint)WeaponId);
        bw.WriteUInt32Be((uint)Count);
        bw.WriteUInt32Be((uint)StuffId);
        bw.WriteUInt32Be((uint)ExpireHours);
    }

    public void Deserialize(Stream input)
    {
        BinaryReader br = new BinaryReader(input);
        WeaponId = (int)br.ReadUInt32Be();
        Count = (int)br.ReadUInt32Be();
        StuffId = (int)br.ReadUInt32Be();
        ExpireHours = (int)br.ReadUInt32Be();
    }
}
