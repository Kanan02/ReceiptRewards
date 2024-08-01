using ReceiptRewards.Domain.Entities;

namespace ReceiptRewards.Domain.Responses
{
    public class PresentDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public PresentDto(Present present)
        {
            Id = present.Id;
            Name = present.Name;
            Quantity = present.Quantity;
            Price = present.Price;
        }
    }
}
