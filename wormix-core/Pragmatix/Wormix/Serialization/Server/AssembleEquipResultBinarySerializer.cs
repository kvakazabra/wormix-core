using wormix_core.Pragmatix.Flox.Serialization.Interfaces;
using wormix_core.Pragmatix.Wormix.Messages.Server;

namespace wormix_core.Pragmatix.Wormix.Serialization.Server;

public class AssembleEquipResultBinarySerializer : AbstractBinaryCommandSerializer<AssembleEquipResult>
{
    protected override uint CommandId => 10099;

    protected override bool IsSecure => true;
}
