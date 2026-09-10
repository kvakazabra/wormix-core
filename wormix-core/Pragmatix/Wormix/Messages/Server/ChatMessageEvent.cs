using wormix_core.Extensions;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;
using wormix_core.Pragmatix.Wormix.Messages.Structures;

namespace wormix_core.Pragmatix.Wormix.Messages.Server;

public struct ChatMessageEvent() : ISerializable
{
    public short State;
    public ChatMessage? Message;

    public uint GetSize()
    {
        return (uint)(
            // State
            2 +
            // Message flag
            2 +
            // Message
            (Message.HasValue ? Message.Value.GetSize() : 0)
        );
    }

    public void Serialize(Stream output)
    {
        BinaryWriter bw = new BinaryWriter(output);
        bw.WriteUInt16Be((ushort)State);
        bw.WriteUInt16Be((ushort)(Message.HasValue ? 1 : 0));
        if (Message.HasValue)
        {
            Message.Value.Serialize(output);
        }
    }
}

