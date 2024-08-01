using ReceiptRewards.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReceiptRewards.Domain.Entities;

public class Receipt : BaseEntity<int>
{
    public Receipt()
    {
        ApprovalDate = CreatedAt.AddDays(14);
    }

    public ReceiptStatus Status { get; set; } = ReceiptStatus.Pending;
    public DateTime ApprovalDate { get; set; }
    public string FiscalId { get; set; } = "";
    public DateTime FiscalDate { get; set; }
    public int Points { get; set; }
    public string? City { get; set; }
    public int UserId { get; set; }
    public User? User { get; set; }
    public ICollection<Product> products { get; set; } = new List<Product>();
}