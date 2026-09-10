using wormix_core.Extensions;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Wormix.Messages.Client;

public struct AddToGroup() : ISerializable
{
    public int ProfileId;
    public short MoneyType;
    public short TeamMemberType;
    public int ReplaceableId;
    public bool Active;

    public uint GetSize()
    {
        return 0; //Not needed
    }

    public void Serialize(Stream output)
    {
        //Not needed
    }
}