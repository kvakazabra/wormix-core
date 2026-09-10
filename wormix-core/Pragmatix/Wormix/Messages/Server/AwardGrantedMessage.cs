using wormix_core.Extensions;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;
using wormix_core.Pragmatix.Wormix.Messages.Structures;

namespace wormix_core.Pragmatix.Wormix.Messages.Server;

public struct AwardGrantedMessage() : ISerializable
{
    public List<GenericAwardStructure> Awards = new();
    public short AwardType;
    public string Attach = "";

    public uint GetSize()
    {
        return (uint)(
            // Awards
            2 + Awards.Sum((x) => x.GetSize() + 2) +
            // AwardType
            2 +
            // Attach
            2 + System.Text.Encoding.UTF8.GetByteCount(Attach)
        );
    }

    public void Serialize(Stream output)
    {
        BinaryWriter bw = new BinaryWriter(output);
        bw.WriteUInt16Be((ushort)Awards.Count);
        Awards.ForEach((x) =>
        {
            bw.WriteUInt16Be((ushort)x.GetSize());
            x.Serialize(output);
        });

        bw.WriteUInt16Be((ushort)AwardType);
        bw.WriteUTF8(Attach);
    }
}

