namespace ReceiptRewards.Application.Options;

public class MessageBrokerOptions
{
    public const string Key = "MessageBroker";
    public string Host { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
}