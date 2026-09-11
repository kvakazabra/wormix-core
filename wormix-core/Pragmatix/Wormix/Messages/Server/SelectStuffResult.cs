using wormix_core.Extensions;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;
using wormix_core.Pragmatix.Wormix.Messages.Structures;

namespace wormix_core.Pragmatix.Wormix.Messages.Server;

public struct SelectStuffResult() : ISerializable
{
    public List<SelectStuffResultStructure> SelectStuffResults = new();

    public uint GetSize()
    {
        return (uint)(
            // SelectStuffResults[]
            2 + SelectStuffResults.Sum((x) => x.GetSize() + 2)
        );
    }

    public void Serialize(Stream output)
    {
        BinaryWriter bw = new BinaryWriter(output);
        bw.WriteUInt16Be((ushort)SelectStuffResults.Count);

        SelectStuffResults.ForEach((x) =>
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
