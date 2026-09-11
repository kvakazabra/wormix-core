using wormix_core.Extensions;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;
using wormix_core.Pragmatix.Wormix.Messages.Structures;

namespace wormix_core.Pragmatix.Wormix.Messages.Server;

public struct GetFriendsForMissionResult() : ISerializable
{
    public List<SimpleProfileStructure> Profiles = new();
    public List<short> States = new();

    public uint GetSize()
    {
        return (uint)(
            // Profiles
            2 + Profiles.Sum((x) => 2 + x.GetSize()) +
            // States
            2 + 2 * States.Count
        );
    }

    public void Serialize(Stream output)
    {
        BinaryWriter bw = new BinaryWriter(output);

        bw.WriteUInt16Be((ushort)Profiles.Count);
        Profiles.ForEach((x) =>
        {
            bw.WriteUInt16Be((ushort)x.GetSize());
            x.Serialize(output);
        });

        bw.WriteUInt16Be((ushort)States.Count);
        States.ForEach((x) => bw.WriteUInt16Be((ushort)x));
    }

    public void Deserialize(Stream input)
    {
        throw new NotSupportedException();
    }
}
