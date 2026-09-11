using wormix_core.Extensions;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Wormix.Messages.Server;

public struct DowngradeWeaponResult() : ISerializable
{
    public short RecipeId;
    public short Result;
    public bool IsSecure;

    public uint GetSize()
    {
        return (uint)(
            // RecipeId
            2 +
            // Result
            2
        );
    }

    public void Serialize(Stream output)
    {
        BinaryWriter bw = new BinaryWriter(output);
        bw.WriteUInt16Be((ushort)RecipeId);
        bw.WriteUInt16Be((ushort)Result);
    }

    public void Deserialize(Stream input)
    {
        throw new NotSupportedException();
    }
}
