using wormix_core.Pragmatix.Flox.Serialization.Interfaces;
using wormix_core.Pragmatix.Wormix.Messages.Client;

namespace wormix_core.Pragmatix.Wormix.Serialization.Client;

public class SearchTheHouseBinarySerializer : AbstractBinaryCommandSerializer<SearchTheHouse>
{
    protected override uint CommandId => 81;

    protected override bool IsSecure => true;
}
