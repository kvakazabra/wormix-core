using wormix_core.Extensions;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;
using wormix_core.Pragmatix.Wormix.Messages.Structures;

namespace wormix_core.Pragmatix.Wormix.Messages.Server;

public struct GetRatingResult() : ISerializable
{
    public List<RatingProfileStructure> UserProfileStructures = new();
    public int Rating;
    public int OldPlace;
    public int Place;
    public short RatingType;
    public short BattleWager;

    public uint GetSize()
    {
        return (uint)(
            // UserProfileStructures
            2 + UserProfileStructures.Sum((x) => 2 + x.GetSize()) +
            // Rating
            4 +
            // OldPlace
            4 +
            // Place
            4 +
            // RatingType
            2 +
            // BattleWager
            2
        );
    }

    public void Serialize(Stream output)
    {
        BinaryWriter bw = new BinaryWriter(output);

        bw.WriteUInt16Be((ushort)UserProfileStructures.Count);
        UserProfileStructures.ForEach((x) =>
        {
            bw.WriteUInt16Be((ushort)x.GetSize());
            x.Serialize(output);
        });

        bw.WriteUInt32Be((uint)Rating);
        bw.WriteUInt32Be((uint)OldPlace);
        bw.WriteUInt32Be((uint)Place);
        bw.WriteUInt16Be((ushort)RatingType);
        bw.WriteUInt16Be((ushort)BattleWager);
    }
}

