
using System.Text.Json.Serialization;

namespace ReceiptRewards.Domain.Requests;

public class OtpRequest
{
    public string Msisdn { get; set; }
    [JsonIgnore]
    public string ServiceName { get; set; } = "sozoyunu";

    public bool IsValidLogin()
    {
        return string.IsNullOrEmpty(Msisdn) ? false: true;
    }

    public bool IsValidRecovery()
    {
        return string.IsNullOrEmpty(Msisdn) ? false : true;
    }
    public bool isValidMsisdn()
    {
        if (string.IsNullOrEmpty(Msisdn))
            return false;

        return true;
    }
}