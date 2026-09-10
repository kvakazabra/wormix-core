using wormix_core.Pragmatix.Flox.Serialization.Interfaces;
using wormix_core.Pragmatix.Wormix.Messages.Server;

namespace wormix_core.Pragmatix.Wormix.Serialization.Server;

public class GetSpecialDealResponseBinarySerializer : AbstractBinaryCommandSerializer<GetSpecialDealResponse>
{
    protected override uint CommandId => 10108;
}
