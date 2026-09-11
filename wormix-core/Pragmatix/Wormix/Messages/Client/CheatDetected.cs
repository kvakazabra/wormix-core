using wormix_core.Extensions;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Wormix.Messages.Client;

public struct CheatDetected() : ISerializable
{
    public string SessionKey = "";
    public short BanType;
    public string BanNote = "";

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
        SessionKey = br.ReadUTF8();
        BanType = (short)br.ReadUInt16Be();
        BanNote = br.ReadUTF8();
    }
}
