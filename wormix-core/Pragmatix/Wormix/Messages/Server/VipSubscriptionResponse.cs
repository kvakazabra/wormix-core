using wormix_core.Extensions;
using wormix_core.Pragmatix.Wormix.Messages.Interfaces;

namespace wormix_core.Pragmatix.Wormix.Messages.Server;

public struct VipSubscriptionResponse() : ISerializable
{
    public int Id;
    public string ItemId = "";
    public short Status;
    public int Price;
    public int Period;
    public int PeriodStartTime;
    public int NextBillTime;
    public bool PendingCancel;
    public short CancelReason;

    public uint GetSize()
    {
        return (uint)(
            // Id
            4 +
            // ItemId
            2 + System.Text.Encoding.UTF8.GetByteCount(ItemId) +
            // Status
            2 +
            // Price
            4 +
            // Period
            4 +
            // PeriodStartTime
            4 +
            // NextBillTime
            4 +
            // PendingCancel
            1 +
            // CancelReason
            2
        );
    }

    public void Serialize(Stream output)
    {
        BinaryWriter bw = new BinaryWriter(output);
        bw.WriteUInt32Be((uint)Id);
        bw.WriteUTF8(ItemId);
        bw.WriteUInt16Be((ushort)Status);
        bw.WriteUInt32Be((uint)Price);
        bw.WriteUInt32Be((uint)Period);
        bw.WriteUInt32Be((uint)PeriodStartTime);
        bw.WriteUInt32Be((uint)NextBillTime);
        bw.Write(PendingCancel);
        bw.WriteUInt16Be((ushort)CancelReason);
    }
}

