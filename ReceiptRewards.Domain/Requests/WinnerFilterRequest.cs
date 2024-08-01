using ReceiptRewards.Domain.Enums;

namespace ReceiptRewards.Domain.Requests
{
    public class WinnerFilterRequest
    {
        public Prize PrizeType { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Msisdn { get; set; }
        public string Code { get; set; }
    }
}
