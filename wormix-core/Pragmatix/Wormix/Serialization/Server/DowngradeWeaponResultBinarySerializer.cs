using wormix_core.Pragmatix.Flox.Serialization.Interfaces;
using wormix_core.Pragmatix.Wormix.Messages.Server;

namespace wormix_core.Pragmatix.Wormix.Serialization.Server;

public class DowngradeWeaponResultBinarySerializer : AbstractBinaryCommandSerializer<DowngradeWeaponResult>
{
    protected override uint CommandId => 10088;

    protected override bool IsSecure => true;
}
