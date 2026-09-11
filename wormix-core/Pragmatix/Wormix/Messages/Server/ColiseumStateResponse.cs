using wormix_core.Extensions;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;
using wormix_core.Pragmatix.Wormix.Messages.Structures;

namespace wormix_core.Pragmatix.Wormix.Messages.Server;

public struct ColiseumStateResponse() : ISerializable
{
    public int Num;
    public bool IsOpen;
    public int WinCount;
    public int DefeatCount;
    public int DrawCount;
    public int Error;
    public List<GladiatorUnitStructure> TeamCandidatesStructures = new();
    public List<GladiatorUnitStructure> TeamStructures = new();
    public int OpenFrom;
    public int OpenTo;
    public int RegenerateCount;
    public int ProfileId;

    public uint GetSize()
    {
        return (uint)(
            // Num
            4 +
            // IsOpen
            1 +
            // WinCount
            4 +
            // DefeatCount
            4 +
            // DrawCount
            4 +
            // Error
            4 +
            // TeamCandidatesStructures
            2 + TeamCandidatesStructures.Sum((x) => x.GetSize() + 2) +
            // TeamStructures
            2 + TeamStructures.Sum((x) => x.GetSize() + 2) +
            // OpenFrom
            4 +
            // OpenTo
            4 +
            4 +
            4
        );
    }

    public void Serialize(Stream output)
    {
        BinaryWriter bw = new BinaryWriter(output);
        bw.WriteUInt32Be((uint)Num);
        bw.Write(IsOpen);
        bw.WriteUInt32Be((uint)WinCount);
        bw.WriteUInt32Be((uint)DefeatCount);
        bw.WriteUInt32Be((uint)DrawCount);
        bw.WriteUInt32Be((uint)Error);

        bw.WriteUInt16Be((ushort)TeamCandidatesStructures.Count);
        TeamCandidatesStructures.ForEach((x) =>
        {
            bw.WriteUInt16Be((ushort)x.GetSize());
            x.Serialize(output);
        });

        bw.WriteUInt16Be((ushort)TeamStructures.Count);
        TeamStructures.ForEach((x) =>
        {
            bw.WriteUInt16Be((ushort)x.GetSize());
            x.Serialize(output);
        });

        bw.WriteUInt32Be((uint)OpenFrom);
        bw.WriteUInt32Be((uint)OpenTo);
        bw.WriteUInt32Be((uint)RegenerateCount);
        bw.WriteUInt32Be((uint)ProfileId);
    }

    public void Deserialize(Stream input)
    {
        throw new NotSupportedException();
    }
}
