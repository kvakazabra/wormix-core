using wormix_core.Pragmatix.Flox.Serialization.Interfaces;
using wormix_core.Pragmatix.Wormix.Messages.Server;

namespace wormix_core.Pragmatix.Wormix.Serialization.Server;

public class BuyRenameCharResultBinarySerializer : AbstractBinaryCommandSerializer<BuyRenameCharResult>
{
    protected override uint CommandId => 10119;

    protected override bool IsSecure => true;
}
