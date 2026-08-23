using wormix_core.Extensions;
using wormix_core.Pragmatix.Flox.Serialization.Interfaces;
using wormix_core.Pragmatix.Flox.Serialization.Internals;
using wormix_core.Pragmatix.Wormix.Messages.Server;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Wormix.Serialization.Server;

public struct AchieveLoginSuccessBinarySerializer : ICommandSerializer
{
    public uint GetCommandId()
    {
        return 13001;
    }

    public void SerializeCommand(ISerializable command, Stream output)
    {
        if (command is AchieveLoginSuccess error)
        {
            BinaryCommandHeader header = new BinaryCommandHeader();
            header.SetCommandId(GetCommandId());
            header.SetLength(error.GetSize());

            header.Write(output);
            error.Serialize(output);
        }
    }

    public ISerializable DeserializeCommand(Stream input, ICommandHeader header)
    {
        //Not needed
        return null!;
    }
}
