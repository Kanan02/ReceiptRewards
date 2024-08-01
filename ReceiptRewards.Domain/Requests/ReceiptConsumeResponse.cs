using ReceiptRewards.Domain.Entities;

namespace ReceiptRewards.Domain.Requests;

public class ReceiptConsumeResponse
{
    public DateTime fiscalDate { get; set; }
    public string fiscalId { get; set; }
    public string tin { get; set; }
    public string? city { get; set; }
    public List<ProductConsumeResponse> products{ get; set; }
}

public class ProductConsumeResponse
{
    public string name{ get; set; }
    public int quantity { get; set; }
    public double price { get; set; }
    public double totalPrice { get; set; }

}

