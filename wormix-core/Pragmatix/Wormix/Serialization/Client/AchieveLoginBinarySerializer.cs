using wormix_core.Extensions;
using wormix_core.Pragmatix.Flox.Serialization.Interfaces;
using wormix_core.Pragmatix.Wormix.Messages.Client;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Wormix.Serialization.Client;

public class AchieveLoginBinarySerializer : ICommandSerializer
{
    public uint GetCommandId()
    {
        return 3001;
    }

    public void SerializeCommand(ISerializable command, Stream output)
    {
        //Not needed
    }

    public ISerializable DeserializeCommand(Stream input, ICommandHeader header)
    {
        AchieveLogin msg = new();

        BinaryReader br = new BinaryReader(input);
        msg.ApplicationId = br.ReadUTF8();
        msg.SocialNetworkId = br.ReadUTF8();
        msg.Id = br.ReadUTF8();
        msg.AuthKey = br.ReadUTF8();
        msg.SendAchievements = br.ReadByte() != 0;

        return msg;
    }
}
