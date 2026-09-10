using wormix_core.Pragmatix.Flox.Serialization.Interfaces;
using wormix_core.Pragmatix.Wormix.Messages.Server;

namespace wormix_core.Pragmatix.Wormix.Serialization.Server;

public class BuySkinResultBinarySerializer : AbstractBinaryCommandSerializer<BuySkinResult>
{
    protected override uint CommandId => 10029;

    protected override bool IsSecure => true;
}
