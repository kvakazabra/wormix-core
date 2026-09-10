using wormix_core.Pragmatix.Flox.Serialization.Interfaces;
using wormix_core.Pragmatix.Wormix.Messages.Server;

namespace wormix_core.Pragmatix.Wormix.Serialization.Server;

public class AchieveLoginSuccessBinarySerializer : AbstractBinaryCommandSerializer<AchieveLoginSuccess>
{
    protected override uint CommandId => 13001;

    protected override bool IsSecure => true;
}
