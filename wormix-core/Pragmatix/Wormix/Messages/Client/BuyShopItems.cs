using wormix_core.Extensions;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;
using wormix_core.Pragmatix.Wormix.Messages.Structures;

namespace wormix_core.Pragmatix.Wormix.Messages.Client;

public struct BuyShopItems() : ISerializable
{
    public List<ShopItemStructure> ShopItems = new();

    public uint GetSize()
    {
        return 0; //Not needed
    }

    public void Serialize(Stream output)
    {
        throw new NotSupportedException();
    }

    public void Deserialize(Stream input)
    {
        BinaryReader br = new BinaryReader(input);
        ushort count = br.ReadUInt16Be();
        for (int i = 0; i < count; i++)
        {
            br.ReadUInt16Be();
            ShopItemStructure item = new();
            item.Deserialize(input);
            ShopItems.Add(item);
        }
    }
}
