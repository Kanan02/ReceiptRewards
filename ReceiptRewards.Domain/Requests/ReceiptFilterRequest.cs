

using ReceiptRewards.Domain.Enums;

namespace ReceiptRewards.Domain.Requests
{
    public class ReceiptFilterRequest
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? Msisdn { get; set; }
        public bool FullMsisdn { get; set; } = true;
        public ReceiptStatus? Status { get; set; }
        public int? Points { get; set; }
    }
}
