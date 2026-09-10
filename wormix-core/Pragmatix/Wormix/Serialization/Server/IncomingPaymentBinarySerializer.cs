using wormix_core.Pragmatix.Flox.Serialization.Interfaces;
using wormix_core.Pragmatix.Wormix.Messages.Server;

namespace wormix_core.Pragmatix.Wormix.Serialization.Server;

public class IncomingPaymentBinarySerializer : AbstractBinaryCommandSerializer<IncomingPayment>
{
    protected override uint CommandId => 10031;

    protected override bool IsSecure => true;
}
