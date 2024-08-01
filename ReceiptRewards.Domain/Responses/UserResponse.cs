using ReceiptRewards.Domain.Entities;
using ReceiptRewards.Domain.Enums;

namespace ReceiptRewards.Domain.Responses;

public class UserResponse
{
    public UserResponse(User user)
    {
        Name = user.Name;
        Email = user.Email;
        Surname = user.Surname;
        Msisdn = user.Msisdn;
        Address = user.Address;
        Instagram = user.Instagram;
        Total = user.Total;
        Pending = user.Pending;
        Spent = user.Spent;
        Remaining = user.Remaining;
        RegisterDate = user.RegisterDate;
        Presents = user.Presents;
        Operator = user.Operator.ToString();
    }

    public string Name { get; set; }
    public string Surname { get; set; }
    public string Msisdn { get; set; }
    public string Email { get; set; }
    public string Address { get; set; }
    public string Instagram { get; set; }
    public string Operator { get; set; }
    public int Total { get; set; }
    public int Pending { get; set; }
    public int Spent { get; set; }
    public int Remaining { get; set; }
    public List<Present> Presents { get; set; }
    public DateTime RegisterDate { get; set; }
}

