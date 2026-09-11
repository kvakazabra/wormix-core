using wormix_core.Extensions;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Wormix.Messages.Client;

public struct GetQuestReward() : ISerializable
{
    public int QuestId;
    public int RewardId;

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
        QuestId = (int)br.ReadUInt32Be();
        RewardId = (int)br.ReadUInt32Be();
    }
}
