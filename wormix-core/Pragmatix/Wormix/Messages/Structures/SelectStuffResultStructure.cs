using wormix_core.Extensions;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Wormix.Messages.Structures;

public struct SelectStuffResultStructure : ISerializable
{
    public const uint Success = 0;
    public const uint Error = 1;

    public int ProfileId;
    public short ResultHat;
    public short HatId;
    public short ResultArtifact;
    public short ArtifactId;

    public uint GetSize()
    {
        return (uint)(
            // ProfileId
            4 +
            // ResultHat
            2 +
            // HatId
            2 +
            // ResultArtifact
            2 +
            // ArtifactId
            2
        );
    }

    public void Serialize(Stream output)
    {
        BinaryWriter bw = new BinaryWriter(output);
        bw.WriteUInt32Be((uint)ProfileId);
        bw.WriteUInt16Be((ushort)ResultHat);
        bw.WriteUInt16Be((ushort)HatId);
        bw.WriteUInt16Be((ushort)ResultArtifact);
        bw.WriteUInt16Be((ushort)ArtifactId);
    }

    public void Deserialize(Stream input)
    {
        BinaryReader br = new BinaryReader(input);
        ProfileId = (int)br.ReadUInt32Be();
        ResultHat = (short)br.ReadUInt16Be();
        HatId = (short)br.ReadUInt16Be();
        ResultArtifact = (short)br.ReadUInt16Be();
        ArtifactId = (short)br.ReadUInt16Be();
    }
}
