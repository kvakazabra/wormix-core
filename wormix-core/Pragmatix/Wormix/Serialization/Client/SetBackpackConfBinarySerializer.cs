using wormix_core.Pragmatix.Flox.Serialization.Interfaces;
using wormix_core.Pragmatix.Wormix.Messages.Client;

namespace wormix_core.Pragmatix.Wormix.Serialization.Client;

public class SetBackpackConfBinarySerializer : AbstractBinaryCommandSerializer<SetBackpackConf>
{
    protected override uint CommandId => 129;
}
