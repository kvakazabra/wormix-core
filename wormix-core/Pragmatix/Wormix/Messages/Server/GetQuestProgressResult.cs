using wormix_core.Extensions;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;
using wormix_core.Pragmatix.Wormix.Messages.Structures;

namespace wormix_core.Pragmatix.Wormix.Messages.Server;

public struct GetQuestProgressResult() : ISerializable
{
    public List<QuestProgressStructure> QuestStructures = new();

    public uint GetSize()
    {
        return (uint)(
            // QuestStructures
            2 + QuestStructures.Sum((x) => 2 + x.GetSize())
        );
    }

    public void Serialize(Stream output)
    {
        BinaryWriter bw = new BinaryWriter(output);

        bw.WriteUInt16Be((ushort)QuestStructures.Count);
        QuestStructures.ForEach((x) =>
        {
            bw.WriteUInt16Be((ushort)x.GetSize());
            x.Serialize(output);
        });
    }
}

