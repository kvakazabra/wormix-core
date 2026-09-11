using wormix_core.Pragmatix.Flox.Serialization.Interfaces;
using wormix_core.Pragmatix.Wormix.Messages.Client;

namespace wormix_core.Pragmatix.Wormix.Serialization.Client;

public class EndTurnBinarySerializer : AbstractBinaryCommandSerializer<EndTurn>
{
    protected override uint CommandId => 120;

    protected override bool IsSecure => true;
}
