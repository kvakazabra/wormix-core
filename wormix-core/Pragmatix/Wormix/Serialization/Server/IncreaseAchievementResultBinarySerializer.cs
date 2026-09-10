using wormix_core.Pragmatix.Flox.Serialization.Interfaces;
using wormix_core.Pragmatix.Wormix.Messages.Server;

namespace wormix_core.Pragmatix.Wormix.Serialization.Server;

public class IncreaseAchievementResultBinarySerializer : AbstractBinaryCommandSerializer<IncreaseAchievementResult>
{
    protected override uint CommandId => 13004;

    protected override bool IsSecure => true;
}
