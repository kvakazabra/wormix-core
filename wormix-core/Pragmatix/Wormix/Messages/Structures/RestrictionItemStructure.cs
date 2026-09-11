using wormix_core.Extensions;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Wormix.Messages.Structures;

public struct RestrictionItemStructure() : ISerializable
{
    public int EndDate;
    public int Reason;
    public List<int> Blocks = new();

    public uint GetSize()
    {
        return (uint)(
            // EndDate
            4 +
            // Reason
            4 +
            // Blocks
            2 + Blocks.Count
        );
    }

    public void Serialize(Stream output)
    {
        BinaryWriter bw = new BinaryWriter(output);
        bw.WriteUInt32Be((uint)EndDate);
        bw.WriteUInt32Be((uint)Reason);

        bw.WriteUInt16Be((ushort)Blocks.Count);
        Blocks.ForEach((x) => bw.Write((byte)x));
    }

    public void Deserialize(Stream input)
    {
        BinaryReader br = new BinaryReader(input);
        EndDate = (int)br.ReadUInt32Be();
        Reason = (int)br.ReadUInt32Be();
        Blocks = new List<int>();
        ushort count = br.ReadUInt16Be();
        for (int i = 0; i < count; i++)
            Blocks.Add(br.ReadByte());
    }
}
