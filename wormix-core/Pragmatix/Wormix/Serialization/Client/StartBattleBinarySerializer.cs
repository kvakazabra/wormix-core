using wormix_core.Pragmatix.Flox.Serialization.Interfaces;
using wormix_core.Pragmatix.Wormix.Messages.Client;

namespace wormix_core.Pragmatix.Wormix.Serialization.Client;

public class StartBattleBinarySerializer : AbstractBinaryCommandSerializer<StartBattle>
{
    protected override uint CommandId => 6;
}
