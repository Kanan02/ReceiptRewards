using System.Text.Json.Serialization;
namespace ReceiptRewards.Domain.Requests;

public class CheckOtpRequest
{
    public string Msisdn { get; set; }
    public string Password { get; set; }
    [JsonIgnore]
    public string ServiceName { get; set; } = "sozoyunu";


}