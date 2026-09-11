using wormix_core.Pragmatix.Flox.Serialization.Interfaces;
using wormix_core.Pragmatix.Wormix.Messages.Client;

namespace wormix_core.Pragmatix.Wormix.Serialization.Client;

public class PumpReactionRatesBinarySerializer : AbstractBinaryCommandSerializer<PumpReactionRates>
{
    protected override uint CommandId => 705;
}
