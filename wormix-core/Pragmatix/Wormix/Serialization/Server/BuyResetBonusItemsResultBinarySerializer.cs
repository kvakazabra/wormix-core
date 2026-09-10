using wormix_core.Pragmatix.Flox.Serialization.Interfaces;
using wormix_core.Pragmatix.Wormix.Messages.Server;

namespace wormix_core.Pragmatix.Wormix.Serialization.Server;

public class BuyResetBonusItemsResultBinarySerializer : AbstractBinaryCommandSerializer<BuyResetBonusItemsResult>
{
    protected override uint CommandId => 13010;

    protected override bool IsSecure => true;
}
