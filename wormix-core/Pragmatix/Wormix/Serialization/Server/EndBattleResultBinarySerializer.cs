using wormix_core.Pragmatix.Flox.Serialization.Interfaces;
using wormix_core.Pragmatix.Wormix.Messages.Server;

namespace wormix_core.Pragmatix.Wormix.Serialization.Server;

public class EndBattleResultBinarySerializer : AbstractBinaryCommandSerializer<EndBattleResult>
{
    protected override uint CommandId => 10121;

    protected override bool IsSecure => true;
}
