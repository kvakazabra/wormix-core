using wormix_core.Extensions;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Wormix.Messages.Server;

public struct EndBattleResult() : ISerializable
{
    public short ValidateResult;
    public int Result;
    public int BattleId;
    public short MissionId;
    public string SessionKey = "";
    public bool IsSecure;

    public uint GetSize()
    {
        return (uint)(
            // ValidateResult
            2 +
            // Result
            4 +
            // BattleId
            4 +
            // MissionId
            2 +
            // SessionKey
            2 + System.Text.Encoding.UTF8.GetByteCount(SessionKey)
        );
    }

    public void Serialize(Stream output)
    {
        BinaryWriter bw = new BinaryWriter(output);
        bw.WriteUInt16Be((ushort)ValidateResult);
        bw.WriteUInt32Be((uint)Result);
        bw.WriteUInt32Be((uint)BattleId);
        bw.WriteUInt16Be((ushort)MissionId);
        bw.WriteUTF8(SessionKey);
    }

    public void Deserialize(Stream input)
    {
        throw new NotSupportedException();
    }
}
