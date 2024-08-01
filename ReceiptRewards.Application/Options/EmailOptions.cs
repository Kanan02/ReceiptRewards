namespace ReceiptRewards.Application.Options;

public class EmailOptions
{
    public const string Key = "EmailSetting";
    public string Host { get; set; }
    public int Port { get; set; }
    public string FromAddress { get; set; }
    public string FromUsername { get; set; }
    public string FromPassword { get; set; }
    public string ToAddress { get; set; }
    public string FromMailboxName { get; set; }
    public string ToMailboxName { get; set; }
    public string Subject { get; set; }
    public string Content { get; set; }
}