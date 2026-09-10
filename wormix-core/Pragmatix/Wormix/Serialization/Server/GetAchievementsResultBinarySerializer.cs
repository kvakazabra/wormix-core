using wormix_core.Pragmatix.Flox.Serialization.Interfaces;
using wormix_core.Pragmatix.Wormix.Messages.Server;

namespace wormix_core.Pragmatix.Wormix.Serialization.Server;

public class GetAchievementsResultBinarySerializer : AbstractBinaryCommandSerializer<GetAchievementsResult>
{
    protected override uint CommandId => 13003;

    protected override bool IsSecure => true;
}
