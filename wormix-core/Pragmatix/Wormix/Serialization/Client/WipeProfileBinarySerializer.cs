using wormix_core.Pragmatix.Flox.Serialization.Interfaces;
using wormix_core.Pragmatix.Wormix.Messages.Client;

namespace wormix_core.Pragmatix.Wormix.Serialization.Client;

public class WipeProfileBinarySerializer : AbstractBinaryCommandSerializer<WipeProfile>
{
    protected override uint CommandId => 48;

    protected override bool IsSecure => true;
}
