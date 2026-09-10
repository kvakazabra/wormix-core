using wormix_core.Extensions;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Wormix.Messages.Server;

public struct SendWipeConfirmCodeResponse() : ISerializable
{
    public byte Result;

    public uint GetSize()
    {
        return (uint)(
            // Result
            1
        );
    }

    public void Serialize(Stream output)
    {
        BinaryWriter bw = new BinaryWriter(output);
        bw.Write(Result);
    }
}

