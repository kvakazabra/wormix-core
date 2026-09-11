using wormix_core.Pragmatix.Flox.Serialization.Interfaces;
using wormix_core.Pragmatix.Wormix.Messages.Client;

namespace wormix_core.Pragmatix.Wormix.Serialization.Client;

public class SetMercenariesTeamMembersBinarySerializer : AbstractBinaryCommandSerializer<SetMercenariesTeamMembers>
{
    protected override uint CommandId => 127;
}
