namespace ReceiptRewards.Application.Services.Abstract;

public interface IEventBus 
{
    Task PublishAsync<T>(T message) where T : class;
}