using wormix_core.Extensions;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Wormix.Messages.Structures;

public struct ChatMessage : ISerializable
{
    public const int PostToChat = 0;
    public const int CraftLegendary = 1;
    public const int DeletedMessage = 2;
    public const int PostSticker = 3;

    public uint Id;
    public short Action;
    public int LogDate;
    public byte SocialId;
    public int ProfileId;
    public string ProfileStringId;
    public string ProfileName;
    public string Message;
    public string Params;

    public uint GetSize()
    {
        return (uint)(
            // Id
            4 +
            // Action
            2 +
            // LogDate
            4 +
            // SocialId
            1 +
            // ProfileId
            4 +
            // ProfileStringId
            2 + System.Text.Encoding.UTF8.GetByteCount(ProfileStringId) +
            // ProfileName
            2 + System.Text.Encoding.UTF8.GetByteCount(ProfileName) +
            // Message
            2 + System.Text.Encoding.UTF8.GetByteCount(Message) +
            // Params
            2 + System.Text.Encoding.UTF8.GetByteCount(Params)
        );
    }

    public void Serialize(Stream output)
    {
        BinaryWriter bw = new BinaryWriter(output);
        bw.WriteUInt32Be(Id);
        bw.WriteUInt16Be((ushort)Action);
        bw.WriteUInt32Be((uint)LogDate);
        bw.Write(SocialId);
        bw.WriteUInt32Be((uint)ProfileId);
        bw.WriteUTF8(ProfileStringId);
        bw.WriteUTF8(ProfileName);
        bw.WriteUTF8(Message);
        bw.WriteUTF8(Params);
    }

    public void Deserialize(Stream input)
    {
        BinaryReader br = new BinaryReader(input);
        Id = br.ReadUInt32Be();
        Action = (short)br.ReadUInt16Be();
        LogDate = (int)br.ReadUInt32Be();
        SocialId = br.ReadByte();
        ProfileId = (int)br.ReadUInt32Be();
        ProfileStringId = br.ReadUTF8();
        ProfileName = br.ReadUTF8();
        Message = br.ReadUTF8();
        Params = br.ReadUTF8();
    }
}
