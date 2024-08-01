using ReceiptRewards.Domain.Entities;
using ReceiptRewards.Domain.Enums;

namespace ReceiptRewards.Domain.Responses
{
    public class ReceiptResponse
    {
        public ReceiptResponse(Receipt receipt)
        {
            Points = receipt.Points;
            AddDate = receipt.CreatedAt;
            Status = receipt.Status;
            ApprovedDate = receipt.ApprovalDate;
            City = receipt.City;
        }

        public DateTime AddDate { get; set; }
        public ReceiptStatus Status { get; set; }
        public DateTime? ApprovedDate { get; set; }
        public string? City { get; set; }
        public int Points { get; set; }
    }
}
