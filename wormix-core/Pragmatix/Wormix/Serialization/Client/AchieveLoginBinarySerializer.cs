using wormix_core.Extensions;
using wormix_core.Pragmatix.Flox.Serialization.Interfaces;
using wormix_core.Pragmatix.Wormix.Messages.Client;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;
using wormix_core.Pragmatix.Wormix.Messages.Server;

namespace wormix_core.Pragmatix.Wormix.Serialization.Client;

public class AchieveLoginBinarySerializer : AbstractBinaryCommandSerializer<AchieveLogin>
{
    protected override uint CommandId => 3001;
}