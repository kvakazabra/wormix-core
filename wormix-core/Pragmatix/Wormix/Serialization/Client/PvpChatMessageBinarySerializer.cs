using wormix_core.Pragmatix.Flox.Serialization.Interfaces;
using wormix_core.Pragmatix.Wormix.Messages.Client;

namespace wormix_core.Pragmatix.Wormix.Serialization.Client;

public class PvpChatMessageBinarySerializer : AbstractBinaryCommandSerializer<PvpChatMessage>
{
    protected override uint CommandId => 17;

    protected override bool IsSecure => true;
}
