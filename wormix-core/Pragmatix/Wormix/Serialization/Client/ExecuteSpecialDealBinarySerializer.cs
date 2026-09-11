using wormix_core.Pragmatix.Flox.Serialization.Interfaces;
using wormix_core.Pragmatix.Wormix.Messages.Client;

namespace wormix_core.Pragmatix.Wormix.Serialization.Client;

public class ExecuteSpecialDealBinarySerializer : AbstractBinaryCommandSerializer<ExecuteSpecialDeal>
{
    protected override uint CommandId => 109;
}
