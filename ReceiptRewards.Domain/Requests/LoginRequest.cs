

using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace ReceiptRewards.Domain.Requests;

public class LoginRequest
{
    [Required]
    public string Msisdn { get; set; }
    [Required]
    public string Password { get; set; }

 
}
