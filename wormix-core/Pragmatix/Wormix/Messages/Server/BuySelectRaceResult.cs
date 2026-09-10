using wormix_core.Extensions;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;
using wormix_core.Pragmatix.Wormix.Messages.Structures;

namespace wormix_core.Pragmatix.Wormix.Messages.Server;

public struct BuySelectRaceResult() : ISerializable
{
    public short Result;
    public List<CostStructure> Costs = new();
    public string SessionKey = "";
    public short Race;
    public byte Skin;
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
            // Race
            2 +
            // Skin
            1
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
        bw.WriteUInt16Be((ushort)Race);
        bw.Write(Skin);
    }
}

