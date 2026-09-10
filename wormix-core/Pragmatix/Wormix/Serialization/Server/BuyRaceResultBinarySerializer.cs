using wormix_core.Pragmatix.Flox.Serialization.Interfaces;
using wormix_core.Pragmatix.Wormix.Messages.Server;

namespace wormix_core.Pragmatix.Wormix.Serialization.Server;

public class BuyRaceResultBinarySerializer : AbstractBinaryCommandSerializer<BuyRaceResult>
{
    protected override uint CommandId => 10028;

    protected override bool IsSecure => true;
}
