using wormix_core.Extensions;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;
using wormix_core.Pragmatix.Wormix.Messages.Structures;

namespace wormix_core.Pragmatix.Wormix.Messages.Server;

public struct GetFriendListPageResult() : ISerializable
{
    public List<UserProfileStructure> ProfileStructures = new();

    public uint GetSize()
    {
        return (uint)(
            // ProfileStructures
            2 + ProfileStructures.Sum((x) => 2 + x.GetSize())
        );
    }

    public void Serialize(Stream output)
    {
        BinaryWriter bw = new BinaryWriter(output);

        bw.WriteUInt16Be((ushort)ProfileStructures.Count);
        ProfileStructures.ForEach((x) =>
        {
            bw.WriteUInt16Be((ushort)x.GetSize());
            x.Serialize(output);
        });
    }
}

