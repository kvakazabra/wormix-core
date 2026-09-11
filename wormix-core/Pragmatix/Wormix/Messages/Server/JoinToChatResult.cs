using wormix_core.Extensions;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;
using wormix_core.Pragmatix.Wormix.Messages.Structures;

namespace wormix_core.Pragmatix.Wormix.Messages.Server;

public struct JoinToChatResult() : ISerializable
{
    public List<ChatMessage> Messages = new();

    public uint GetSize()
    {
        return (uint)(
            // Messages
            2 + Messages.Sum((x) => 2 + x.GetSize())
        );
    }

    public void Serialize(Stream output)
    {
        BinaryWriter bw = new BinaryWriter(output);

        bw.WriteUInt16Be((ushort)Messages.Count);
        Messages.ForEach((x) =>
        {
            bw.WriteUInt16Be(1); //structure present flag
            x.Serialize(output);
        });
    }

    public void Deserialize(Stream input)
    {
        throw new NotSupportedException();
    }
}
