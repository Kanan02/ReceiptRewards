using ReceiptRewards.Domain.Enums;

namespace ReceiptRewards.Domain.Requests
{
    public class UpdateReceiptRequest
    {
        public int ReceiptId { get; set; }
        public ReceiptStatus Status { get; set; }
        public int Points { get; set; }
    }
}
