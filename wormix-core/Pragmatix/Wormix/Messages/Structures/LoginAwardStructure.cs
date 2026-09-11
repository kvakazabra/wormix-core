using wormix_core.Extensions;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Wormix.Messages.Structures;

public struct LoginAwardStructure : ISerializable
{
    public short AwardType;
    public List<GenericAwardStructure> Awards;
    public string Attach;

    public uint GetSize()
    {
        uint awardsSize = 0;
        foreach (var award in Awards)
        {
            awardsSize += 2 + award.GetSize();
        }

        return (uint)(
            awardsSize +
            // AwardType
            2 +
            // awards count prefix
            2 +
            // Attach
            2 + System.Text.Encoding.UTF8.GetByteCount(Attach)
        );
    }

    public void Serialize(Stream output)
    {
        BinaryWriter bw = new BinaryWriter(output);
        bw.WriteUInt16Be((ushort)AwardType);
        bw.WriteUInt16Be((ushort)Awards.Count);
        foreach (var award in Awards)
        {
            bw.WriteUInt16Be(0);
            award.Serialize(output);
        }
        bw.WriteUTF8(Attach);
    }

    public void Deserialize(Stream input)
    {
        BinaryReader br = new BinaryReader(input);
        AwardType = (short)br.ReadUInt16Be();
        Awards = new List<GenericAwardStructure>();
        ushort count = br.ReadUInt16Be();
        for (int i = 0; i < count; i++)
        {
            br.ReadUInt16Be();
            GenericAwardStructure award = new GenericAwardStructure();
            award.Deserialize(input);
            Awards.Add(award);
        }
        Attach = br.ReadUTF8();
    }
}
