namespace ReceiptRewards.Domain.Requests
{
    public class ApproveRequest
    {
        public int ReceiptId { get; set; }
        public bool IsApproved { get; set; }
    }
}
