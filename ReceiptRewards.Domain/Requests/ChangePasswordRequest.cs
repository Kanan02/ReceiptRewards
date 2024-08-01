using System.ComponentModel.DataAnnotations;

namespace ReceiptRewards.Domain.Requests
{
    public class ChangePasswordRequest
    {
        [Required]
        [MaxLength(20)]
        public string OldPassword { get; set; }
        [Required]
        [MaxLength(20)]
        public string NewPassword { get; set; }
    }
}
