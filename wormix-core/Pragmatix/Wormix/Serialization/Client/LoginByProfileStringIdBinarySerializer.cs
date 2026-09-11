using wormix_core.Pragmatix.Flox.Serialization.Interfaces;
using wormix_core.Pragmatix.Wormix.Messages.Client;

namespace wormix_core.Pragmatix.Wormix.Serialization.Client;

public class LoginByProfileStringIdBinarySerializer : AbstractBinaryCommandSerializer<LoginByProfileStringId>
{
    protected override uint CommandId => 20;

    protected override bool IsSecure => true;
}
