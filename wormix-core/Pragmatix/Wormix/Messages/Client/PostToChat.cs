using wormix_core.Extensions;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Wormix.Messages.Client;

public struct PostToChat() : ISerializable
{
    public short Action;
    public string ProfileName = "";
    public string Message = "";

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
        Action = (short)br.ReadUInt16Be();
        ProfileName = br.ReadUTF8();
        Message = br.ReadUTF8();
    }
}
