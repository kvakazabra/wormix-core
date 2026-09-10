using wormix_core.Pragmatix.Flox.Serialization.Interfaces;
using wormix_core.Pragmatix.Wormix.Messages.Server;

namespace wormix_core.Pragmatix.Wormix.Serialization.Server;

public class GetColiseumRewardResponseBinarySerializer : AbstractBinaryCommandSerializer<GetColiseumRewardResponse>
{
    protected override uint CommandId => 10114;

    protected override bool IsSecure => true;
}
