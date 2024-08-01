namespace ReceiptRewards.Application.Services.Abstract;

public interface IEmailService
{
    void Send(string text, string emailName, string emailAddress);
}