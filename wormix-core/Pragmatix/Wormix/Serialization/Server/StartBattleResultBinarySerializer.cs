using wormix_core.Pragmatix.Flox.Serialization.Interfaces;
using wormix_core.Pragmatix.Wormix.Messages.Server;

namespace wormix_core.Pragmatix.Wormix.Serialization.Server;

public class StartBattleResultBinarySerializer : AbstractBinaryCommandSerializer<StartBattleResult>
{
    protected override uint CommandId => 10006;

    protected override bool IsSecure => true;
}