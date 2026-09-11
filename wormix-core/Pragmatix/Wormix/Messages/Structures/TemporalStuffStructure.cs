using wormix_core.Extensions;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Wormix.Messages.Structures;

public struct TemporalStuffStructure : ISerializable
{
    public int StuffId;
    public int ExpireDate;

    public uint GetSize()
    {
        return (uint)(
            // StuffId
            2 +
            // ExpireDate
            4
        );
    }

    public void Serialize(Stream output)
    {
        BinaryWriter bw = new BinaryWriter(output);
        bw.WriteUInt16Be((ushort)StuffId);
        bw.WriteUInt32Be((uint)ExpireDate);
    }

    public void Deserialize(Stream input)
    {
        BinaryReader br = new BinaryReader(input);
        StuffId = (short)br.ReadUInt16Be();
        ExpireDate = (int)br.ReadUInt32Be();
    }
}
