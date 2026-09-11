using wormix_core.Extensions;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Wormix.Messages.Structures;

public struct UnluckyCraftCount : ISerializable
{
    public int RecipeId;
    public int Count;

    public uint GetSize()
    {
        return (uint)(
            // RecipeId
            2 +
            // Count
            4
        );
    }

    public void Serialize(Stream output)
    {
        BinaryWriter bw = new BinaryWriter(output);
        bw.WriteUInt16Be((ushort)RecipeId);
        bw.WriteUInt32Be((uint)Count);
    }

    public void Deserialize(Stream input)
    {
        throw new NotSupportedException();
    }
}
