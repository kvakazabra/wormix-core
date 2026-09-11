using wormix_core.Extensions;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Wormix.Messages.Client;

public struct SendWipeConfirmCode() : ISerializable
{
    public int Level;
    public int Experience;
    public int Rating;

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
        Level = (int)br.ReadUInt32Be();
        Experience = (int)br.ReadUInt32Be();
        Rating = (int)br.ReadUInt32Be();
    }
}
