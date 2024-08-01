namespace ReceiptRewards.Domain.Entities;

public class Product : BaseEntity<int>
{
    public string Name { get; set; }
    public double Price { get; set; }  
    public double Quantity {  get; set; }
    public double TotalPrice { get; set; }
    public int ReceiptId { get; set; }
    public Receipt? Receipt { get; set; }

}