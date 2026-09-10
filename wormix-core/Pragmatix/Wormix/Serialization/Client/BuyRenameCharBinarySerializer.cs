using wormix_core.Extensions;
using wormix_core.Pragmatix.Flox.Serialization.Interfaces;
using wormix_core.Pragmatix.Wormix.Messages.Client;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Wormix.Serialization.Client;

public class BuyRenameCharBinarySerializer : ICommandSerializer
{
    public uint GetCommandId()
    {
        return 119;
    }

    public void SerializeCommand(ISerializable command, Stream output)
    {
        //Not needed
    }

    public ISerializable DeserializeCommand(Stream input, ICommandHeader header)
    {
        BuyRenameChar msg = new();

        BinaryReader br = new BinaryReader(input);
        msg.TeamMemberId = (int)br.ReadUInt32Be();
        msg.Name = br.ReadUTF8();
        msg.MoneyType = (short)br.ReadUInt16Be();

        return msg;
    }
}
