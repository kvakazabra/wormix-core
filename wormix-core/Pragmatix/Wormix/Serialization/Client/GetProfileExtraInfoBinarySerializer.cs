using wormix_core.Pragmatix.Flox.Serialization.Interfaces;
using wormix_core.Pragmatix.Wormix.Messages.Client;

namespace wormix_core.Pragmatix.Wormix.Serialization.Client;

public class GetProfileExtraInfoBinarySerializer : AbstractBinaryCommandSerializer<GetProfileExtraInfo>
{
    protected override uint CommandId => 141;
}
