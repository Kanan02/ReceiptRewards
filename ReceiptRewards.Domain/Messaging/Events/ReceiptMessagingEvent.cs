using ReceiptRewards.Domain.Entities;

namespace ReceiptRewards.Domain.Messaging.Events;

public class ReceiptMessagingEvent
{
    public Receipt Receipt { get; init; }
}