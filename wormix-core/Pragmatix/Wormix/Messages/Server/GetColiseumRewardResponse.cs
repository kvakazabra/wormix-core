using wormix_core.Extensions;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;
using wormix_core.Pragmatix.Wormix.Messages.Structures;

namespace wormix_core.Pragmatix.Wormix.Messages.Server;

public struct GetColiseumRewardResponse() : ISerializable
{
    public List<GenericAwardStructure> Reward = new();
    public string SessionKey = "";

    public uint GetSize()
    {
        return (uint)(
            // Reward
            2 + Reward.Sum((x) => 2 + x.GetSize()) +
            // SessionKey
            2 + System.Text.Encoding.UTF8.GetByteCount(SessionKey)
        );
    }

    public void Serialize(Stream output)
    {
        BinaryWriter bw = new BinaryWriter(output);

        bw.WriteUInt16Be((ushort)Reward.Count);
        Reward.ForEach((x) =>
        {
            bw.WriteUInt16Be((ushort)x.GetSize());
            x.Serialize(output);
        });

        bw.WriteUTF8(SessionKey);
    }

    public void Deserialize(Stream input)
    {
        throw new NotSupportedException();
    }
}
