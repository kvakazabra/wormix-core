using wormix_core.Extensions;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Wormix.Messages.Structures;

public struct WeaponStructure : ISerializable
{
    public uint Id;
    public int Count;
    
    public uint GetSize()
    {
        return (uint)(
            // Id
            4 +
            // Count
            4
        );
    }

    public void Serialize(Stream output)
    {
        BinaryWriter bw = new BinaryWriter(output);
        bw.WriteUInt32Be(Id);
        bw.WriteUInt32Be((uint)Count);
    }
}

