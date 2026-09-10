using wormix_core.Pragmatix.Flox.Serialization.Interfaces;
using wormix_core.Pragmatix.Wormix.Messages.Server;

namespace wormix_core.Pragmatix.Wormix.Serialization.Server;

public class ShopResultBinarySerializer : AbstractBinaryCommandSerializer<ShopResult>
{
    protected override uint CommandId => 10003;

    protected override bool IsSecure => true;
}
