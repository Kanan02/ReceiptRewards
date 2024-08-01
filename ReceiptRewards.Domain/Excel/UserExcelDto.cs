using ReceiptRewards.Domain.Responses;

namespace ReceiptRewards.Domain.Excel
{
    public class UserExcelDto
    {
        public UserExcelDto(UserResponse user)
        {
            Name = user.Name;
            Surname = user.Surname;
            Msisdn = user.Msisdn;
            Email = user.Email;
            Address = user.Address;
            RegisterDate = user.RegisterDate.ToString("yyyy-MM-dd HH:mm:ss");
            Total= user.Total;
            Pending= user.Pending;
            Spent= user.Spent;
            Remaining= user.Remaining;
            Presents = String.Join(", ",user.Presents);
            
        }

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Msisdn { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string RegisterDate { get; set; }
        public int Total { get; set; }
        public int Pending { get; set; }
        public int Spent { get; set; }
        public int Remaining { get; set; }
        public string Presents { get; set; }
    }
}
