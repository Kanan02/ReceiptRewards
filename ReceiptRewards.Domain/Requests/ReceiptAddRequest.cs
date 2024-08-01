using System.ComponentModel.DataAnnotations;

namespace ReceiptRewards.Domain.Requests
{
    public class ReceiptAddRequest
    {
        [Required]
        public string FiscalId { get; set; }
    }
}
