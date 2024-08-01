using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;
using ReceiptRewards.Application.Options;
using ReceiptRewards.Application.Services.Abstract;

namespace ReceiptRewards.Application.Services.Concrete;

public class EmailService : IEmailService
{
    private readonly EmailOptions _emailOptions;

    public EmailService(IOptionsSnapshot<EmailOptions> emailOptions)
    {
        _emailOptions = emailOptions.Value;
    }

    public void Send(string text, string emailName, string emailAddress)
    {
        var message = new MimeMessage();
        message.From.Add(new MailboxAddress(_emailOptions.FromMailboxName, _emailOptions.FromAddress));
        message.To.Add(new MailboxAddress(emailName, emailAddress));
        message.Subject = _emailOptions.Subject;

        message.Body = new TextPart("plain")
        {
            Text = _emailOptions.Content + text
        };

        using var client = new SmtpClient();
        client.ServerCertificateValidationCallback = (s, c, h, e) => true;
        client.Connect(_emailOptions.Host, _emailOptions.Port, false);

        client.Authenticate(_emailOptions.FromUsername, _emailOptions.FromPassword);

        client.Send(message);
        client.Disconnect(true);
    }
}