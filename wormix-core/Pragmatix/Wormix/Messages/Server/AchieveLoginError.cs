using wormix_core.Extensions;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Wormix.Messages.Server;

public struct AchieveLoginError : ISerializable
{
    public int Code;

    public uint GetSize()
    {
        return 4; // Result sizeof
    }

    public void Serialize(Stream output)
    {
        BinaryWriter bw = new BinaryWriter(output);
        bw.WriteUInt32Be((uint)Code);
    }
}