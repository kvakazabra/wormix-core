using wormix_core.Pragmatix.Flox.Serialization.Interfaces;
using wormix_core.Pragmatix.Wormix.Messages.Server;

namespace wormix_core.Pragmatix.Wormix.Serialization.Server;

public class MoveProfileSecureTokenBinarySerializer : AbstractBinaryCommandSerializer<MoveProfileSecureToken>
{
    protected override uint CommandId => 10139;

    protected override bool IsSecure => true;
}
