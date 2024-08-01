using System.ComponentModel.DataAnnotations;

namespace ReceiptRewards.Domain.Requests;

public class RegisterRequest
{
    [Required]
    public string Name { get; set; }

    [Required]
    public string Surname { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    public string? Address { get; set; }
    public string? Instagram { get; set; }
    [Required]
    public string Msisdn { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [Required]
    [DataType(DataType.Password)]
    [Compare("Password")]
    public string ConfirmPassword { get; set; }

    [Required]
    public bool IsTerms { get; set; }
}