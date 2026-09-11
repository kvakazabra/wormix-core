using wormix_core.Extensions;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Wormix.Messages.Structures;

public struct PumpReactionRateStructure : ISerializable
{
    public uint FriendId;
    public int Result;
    
    public uint GetSize()
    {
        return (uint)(
            // FriendId
            4 +
            // Result
            1
        );
    }

    public void Serialize(Stream output)
    {
        BinaryWriter bw = new BinaryWriter(output);
        bw.WriteUInt32Be(FriendId);
        bw.Write((byte)Result);
    }

    public void Deserialize(Stream input)
    {
        BinaryReader br = new BinaryReader(input);
        FriendId = br.ReadUInt32Be();
        Result = br.ReadByte();
    }
}
