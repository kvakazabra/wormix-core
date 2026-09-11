using wormix_core.Pragmatix.Flox.Serialization.Interfaces;
using wormix_core.Pragmatix.Wormix.Messages.Client;

namespace wormix_core.Pragmatix.Wormix.Serialization.Client;

public class GetMoveProfileSecureTokenBinarySerializer : AbstractBinaryCommandSerializer<GetMoveProfileSecureToken>
{
    protected override uint CommandId => 139;

    protected override bool IsSecure => true;
}
