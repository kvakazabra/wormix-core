using wormix_core.Pragmatix.Flox.Serialization.Interfaces;
using wormix_core.Pragmatix.Wormix.Messages.Server;

namespace wormix_core.Pragmatix.Wormix.Serialization.Server;

public class ChooseBonusItemResultBinarySerializer : AbstractBinaryCommandSerializer<ChooseBonusItemResult>
{
    protected override uint CommandId => 13006;

    protected override bool IsSecure => true;
}
