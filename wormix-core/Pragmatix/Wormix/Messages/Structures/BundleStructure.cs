using wormix_core.Extensions;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Wormix.Messages.Structures;

public struct BundleStructure : ISerializable
{
    public int ExpireInSeconds;
    public string Code;
    public int Order;
    public int Discount;
    public float Votes;
    public List<GenericAwardStructure> Items;

    public uint GetSize()
    {
        uint itemsSize = 0;
        foreach (var item in Items)
        {
            itemsSize += 2 + item.GetSize();
        }

        return (uint)(
            itemsSize +
            // ExpireInSeconds
            4 +
            // Code
            2 + System.Text.Encoding.UTF8.GetByteCount(Code) +
            // Order
            4 +
            // Discount
            4 +
            // Votes (float)
            4 +
            // items count prefix
            2
        );
    }

    public void Serialize(Stream output)
    {
        BinaryWriter bw = new BinaryWriter(output);
        bw.WriteUInt32Be((uint)ExpireInSeconds);
        bw.WriteUTF8(Code);
        bw.WriteUInt32Be((uint)Order);
        bw.WriteUInt32Be((uint)Discount);
        bw.Write(BitConverter.GetBytes(Votes).Reverse().ToArray());
        bw.WriteUInt16Be((ushort)Items.Count);
        foreach (var item in Items)
        {
            bw.WriteUInt16Be(0);
            item.Serialize(output);
        }
    }

    public void Deserialize(Stream input)
    {
        throw new NotSupportedException();
    }
}
