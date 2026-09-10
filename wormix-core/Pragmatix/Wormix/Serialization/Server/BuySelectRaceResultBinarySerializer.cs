using wormix_core.Pragmatix.Flox.Serialization.Interfaces;
using wormix_core.Pragmatix.Wormix.Messages.Server;

namespace wormix_core.Pragmatix.Wormix.Serialization.Server;

public class BuySelectRaceResultBinarySerializer : AbstractBinaryCommandSerializer<BuySelectRaceResult>
{
    protected override uint CommandId => 10050;

    protected override bool IsSecure => true;
}
