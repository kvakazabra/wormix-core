using wormix_core.Pragmatix.Flox.Serialization.Interfaces;
using wormix_core.Pragmatix.Wormix.Messages.Server;

namespace wormix_core.Pragmatix.Wormix.Serialization.Server;

public class BuyGroupSlotResultBinarySerializer : AbstractBinaryCommandSerializer<BuyGroupSlotResult>
{
    protected override uint CommandId => 10122;

    protected override bool IsSecure => true;
}
