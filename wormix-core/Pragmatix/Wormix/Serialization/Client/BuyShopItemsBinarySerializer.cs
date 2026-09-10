using wormix_core.Extensions;
using wormix_core.Pragmatix.Flox.Serialization.Interfaces;
using wormix_core.Pragmatix.Wormix.Messages.Client;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;
using wormix_core.Pragmatix.Wormix.Messages.Structures;

namespace wormix_core.Pragmatix.Wormix.Serialization.Client;

public class BuyShopItemsBinarySerializer : ICommandSerializer
{
    public uint GetCommandId()
    {
        return 3;
    }

    public void SerializeCommand(ISerializable command, Stream output)
    {
        //Not needed
    }

    public ISerializable DeserializeCommand(Stream input, ICommandHeader header)
    {
        BuyShopItems msg = new();

        BinaryReader br = new BinaryReader(input);
        ushort count = br.ReadUInt16Be();
        for (int i = 0; i < count; i++)
        {
            br.ReadUInt16Be();
            ShopItemStructure item = new();
            item.Id = br.ReadUInt32Be();
            item.Count = (int)br.ReadUInt32Be();
            item.MoneyType = (int)br.ReadUInt32Be();
            msg.ShopItems.Add(item);
        }

        return msg;
    }
}
