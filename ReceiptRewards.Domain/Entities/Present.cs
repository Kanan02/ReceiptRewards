namespace ReceiptRewards.Domain.Entities
{
    public class Present : BaseEntity<int>
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public List<User>? Users { get; set; }
        public override string ToString()
        {
            return Name;
        }
    }
}
