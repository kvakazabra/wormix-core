using wormix_core.Extensions;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Wormix.Messages.Server;

public struct MercenariesStateResponse() : ISerializable
{
    public int Num;
    public bool IsOpen;
    public int Win;
    public int Defeat;
    public int Draw;
    public int TotalWin;
    public int TotalDefeat;
    public int TotalDraw;
    public int Error;
    public List<byte> Team = new();
    public int AttemptsRemainToday;

    public uint GetSize()
    {
        return (uint)(
            // Num
            4 +
            // IsOpen
            1 +
            // Win
            4 +
            // Defeat
            4 +
            // Draw
            4 +
            // TotalWin
            4 +
            // TotalDefeat
            4 +
            // TotalDraw
            4 +
            // Error
            4 +
            // Team
            2 + Team.Count +
            // AttemptsRemainToday
            4
        );
    }

    public void Serialize(Stream output)
    {
        BinaryWriter bw = new BinaryWriter(output);

        bw.WriteUInt32Be((uint)Num);
        bw.Write(IsOpen);
        bw.WriteUInt32Be((uint)Win);
        bw.WriteUInt32Be((uint)Defeat);
        bw.WriteUInt32Be((uint)Draw);
        bw.WriteUInt32Be((uint)TotalWin);
        bw.WriteUInt32Be((uint)TotalDefeat);
        bw.WriteUInt32Be((uint)TotalDraw);
        bw.WriteUInt32Be((uint)Error);

        bw.WriteUInt16Be((ushort)Team.Count);
        Team.ForEach((x) => bw.Write(x));

        bw.WriteUInt32Be((uint)AttemptsRemainToday);
    }

    public void Deserialize(Stream input)
    {
        throw new NotSupportedException();
    }
}
