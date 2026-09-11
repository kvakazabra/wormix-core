using wormix_core.Pragmatix.Flox.Serialization.Interfaces;
using wormix_core.Pragmatix.Wormix.Messages.Client;

namespace wormix_core.Pragmatix.Wormix.Serialization.Client;

public class CheatDetectedBinarySerializer : AbstractBinaryCommandSerializer<CheatDetected>
{
    protected override uint CommandId => 87;

    protected override bool IsSecure => true;
}
