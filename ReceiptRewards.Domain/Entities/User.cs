using ReceiptRewards.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReceiptRewards.Domain.Entities;


public class User : BaseEntity<int>
{
    [Required]
    public string Name { get; set; }
    [Required]
    public string Surname { get; set; }
    [Required]
    public string Msisdn { get; set; }
    public string Email { get; set; }
    public string Password {  get; set; }
    public Operator Operator { get; set; }
    public string? Address { get; set; }
    public string? Instagram { get; set; }
    
    public int Total { get; set; }
    public int Pending { get; set; }
    public int Spent { get; set; }
    public int Remaining { get; set; }


    [Required]
    public Role Role { get; set; } = Role.User; 
    public DateTime RegisterDate { get; set; } = DateTime.Now;
    public List<Present>? Presents { get; set; }
    public ICollection<Receipt>? Receipts { get; set; }
}

