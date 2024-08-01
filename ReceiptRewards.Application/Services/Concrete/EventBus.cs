using MassTransit;
using ReceiptRewards.Application.Services.Abstract;

namespace ReceiptRewards.Application.Services.Concrete;

public class EventBus : IEventBus
{
    private readonly IPublishEndpoint _publishEndpoint;

    public EventBus(IPublishEndpoint publishEndpoint)
    {
        _publishEndpoint = publishEndpoint;
    }

    public Task PublishAsync<T>(T message) where T : class =>
        _publishEndpoint.Publish<T>(message);

}