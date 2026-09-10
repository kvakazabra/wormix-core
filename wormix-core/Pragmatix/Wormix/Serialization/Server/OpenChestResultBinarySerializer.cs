using wormix_core.Pragmatix.Flox.Serialization.Interfaces;
using wormix_core.Pragmatix.Wormix.Messages.Server;

namespace wormix_core.Pragmatix.Wormix.Serialization.Server;

public class OpenChestResultBinarySerializer : AbstractBinaryCommandSerializer<OpenChestResult>
{
    protected override uint CommandId => 10102;

    protected override bool IsSecure => true;
}
