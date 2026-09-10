using wormix_core.Extensions;
using wormix_core.Pragmatix.Flox.Serialization.Interfaces;
using wormix_core.Pragmatix.Wormix.Messages.Client;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Wormix.Serialization.Client;

public class IncreaseAchievementsBinarySerializer : ICommandSerializer
{
    public uint GetCommandId()
    {
        return 3003;
    }

    public void SerializeCommand(ISerializable command, Stream output)
    {
        //Not needed
    }

    public ISerializable DeserializeCommand(Stream input, ICommandHeader header)
    {
        IncreaseAchievements msg = new();

        BinaryReader br = new BinaryReader(input);
        msg.SessionId = br.ReadUTF8();
        ushort n = br.ReadUInt16Be();
        for (int i = 0; i < n; i++)
            msg.AchievementsIndex.Add((int)br.ReadUInt32Be());
        n = br.ReadUInt16Be();
        for (int i = 0; i < n; i++)
            msg.AchievementsRise.Add((int)br.ReadUInt32Be());
        n = br.ReadUInt16Be();
        for (int i = 0; i < n; i++)
            msg.BoolAchievements.Add((int)br.ReadUInt32Be());
        msg.TimeScale = br.ReadUInt32Be();

        return msg;
    }
}
