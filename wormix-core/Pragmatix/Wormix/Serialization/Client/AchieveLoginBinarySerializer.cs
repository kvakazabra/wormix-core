using wormix_core.Extensions;
using wormix_core.Pragmatix.Flox.Secure;
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
        AchieveLogin achieveLogin = new();

        BinaryReader br = new BinaryReader(input);
        achieveLogin.ApplicationId = br.ReadUTF8();
        achieveLogin.SocialNetworkId = br.ReadUTF8();
        achieveLogin.Id = br.ReadUTF8();
        achieveLogin.AuthKey = br.ReadUTF8();
        achieveLogin.SendAchievements = br.ReadBoolean();
        return achieveLogin;
    }
}
