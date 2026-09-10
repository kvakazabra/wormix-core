using wormix_core.Extensions;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;
using wormix_core.Pragmatix.Wormix.Messages.Structures;

namespace wormix_core.Pragmatix.Wormix.Messages.Server;

public struct MercenariesDefsResponse() : ISerializable
{
    public List<MercenariesTeamMember> MercenariesDefs = new();

    public uint GetSize()
    {
        return (uint)(
            // MercenariesDefs
            2 + MercenariesDefs.Sum((x) => 2 + x.GetSize())
        );
    }

    public void Serialize(Stream output)
    {
        BinaryWriter bw = new BinaryWriter(output);

        bw.WriteUInt16Be((ushort)MercenariesDefs.Count);
        MercenariesDefs.ForEach((x) =>
        {
            bw.WriteUInt16Be((ushort)x.GetSize());
            x.Serialize(output);
        });
    }
}

