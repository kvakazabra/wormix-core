using wormix_core.Extensions;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;
using wormix_core.Pragmatix.Wormix.Messages.Structures;

namespace wormix_core.Pragmatix.Wormix.Messages.Server;

public struct BuySkinResult() : ISerializable
{
    public short Result;
    public List<CostStructure> Costs = new();
    public string SessionKey = "";
    public byte Skin;
    public List<byte> Skins = new();
    public bool IsSecure;

    public uint GetSize()
    {
        return (uint)(
            // Result
            2 +
            // Costs
            2 + Costs.Sum((x) => x.GetSize() + 2) +
            // SessionKey
            2 + System.Text.Encoding.UTF8.GetByteCount(SessionKey) +
            // Skin
            1 +
            // Skins
            2 + Skins.Count
        );
    }

    public void Serialize(Stream output)
    {
        BinaryWriter bw = new BinaryWriter(output);
        bw.WriteUInt16Be((ushort)Result);
        bw.WriteUInt16Be((ushort)Costs.Count);
        Costs.ForEach((x) =>
        {
            bw.WriteUInt16Be((ushort)x.GetSize());
            x.Serialize(output);
        });
        bw.WriteUTF8(SessionKey);
        bw.Write(Skin);

        bw.WriteUInt16Be((ushort)Skins.Count);
        Skins.ForEach((x) => bw.Write(x));
    }

    public void Deserialize(Stream input)
    {
        throw new NotSupportedException();
    }
}
