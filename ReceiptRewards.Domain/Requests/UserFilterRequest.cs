using ReceiptRewards.Domain.Enums;
using ReceiptRewards.Domain.Requests.Pagination;

namespace ReceiptRewards.Domain.Requests;

public class UserFilterRequest 
{
    
    public UserFilterRequest()
    {
        OrderBy = "Name";
    }
    public string? Msisdn { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public Operator? Operator { get; set; } = null;
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public string? OrderBy { get; set; }
    public bool ValidYearRange => (StartDate == null & EndDate == null) || (EndDate > StartDate);
}
