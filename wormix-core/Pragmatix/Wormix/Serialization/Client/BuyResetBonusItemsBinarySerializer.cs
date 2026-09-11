using wormix_core.Pragmatix.Flox.Serialization.Interfaces;
using wormix_core.Pragmatix.Wormix.Messages.Client;

namespace wormix_core.Pragmatix.Wormix.Serialization.Client;

public class BuyResetBonusItemsBinarySerializer : AbstractBinaryCommandSerializer<BuyResetBonusItems>
{
    protected override uint CommandId => 3010;

    protected override bool IsSecure => true;
}
