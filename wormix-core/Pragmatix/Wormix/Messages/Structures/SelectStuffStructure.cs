using wormix_core.Extensions;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Wormix.Messages.Structures;

public struct SelectStuffStructure : ISerializable
{
    public int ProfileId;
    public short HatId;
    public short ArtifactId;

    public uint GetSize()
    {
        return (uint)(
            // ProfileId
            4 +
            // HatId
            2 +
            // ArtifactId
            2
        );
    }

    public void Serialize(Stream output)
    {
        BinaryWriter bw = new BinaryWriter(output);
        bw.WriteUInt32Be((uint)ProfileId);
        bw.WriteUInt16Be((ushort)HatId);
        bw.WriteUInt16Be((ushort)ArtifactId);
    }

    public void Deserialize(Stream input)
    {
        BinaryReader br = new BinaryReader(input);
        ProfileId = (int)br.ReadUInt32Be();
        HatId = (short)br.ReadUInt16Be();
        ArtifactId = (short)br.ReadUInt16Be();
    }
}
