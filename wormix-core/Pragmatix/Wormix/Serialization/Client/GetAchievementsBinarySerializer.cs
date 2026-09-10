using wormix_core.Extensions;
using wormix_core.Pragmatix.Flox.Serialization.Interfaces;
using wormix_core.Pragmatix.Wormix.Messages.Client;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Wormix.Serialization.Client;

public class GetAchievementsBinarySerializer : ICommandSerializer
{
    public uint GetCommandId()
    {
        return 3002;
    }

    public void SerializeCommand(ISerializable command, Stream output)
    {
        //Not needed
    }

    public ISerializable DeserializeCommand(Stream input, ICommandHeader header)
    {
        GetAchievements msg = new();

        BinaryReader br = new BinaryReader(input);
        msg.ProfileId = br.ReadUTF8();
        msg.InvestedAwardPoints = br.ReadByte();

        return msg;
    }
}
