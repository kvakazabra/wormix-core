using wormix_core.Extensions;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Wormix.Messages.Server;

public struct ReagentsForProfile() : ISerializable
{
    public List<int> Reagents = new();

    public uint GetSize()
    {
        return (uint)(
            // Reagents[]
            2 + 4 * Reagents.Count
        );
    }

    public void Serialize(Stream output)
    {
        BinaryWriter bw = new BinaryWriter(output);
        bw.WriteUInt16Be((ushort)Reagents.Count);
        Reagents.ForEach((x) => bw.WriteUInt32Be((uint)x));
    }

    public void Deserialize(Stream input)
    {
        throw new NotSupportedException();
    }
}
