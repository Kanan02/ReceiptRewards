using ReceiptRewards.Domain.Entities;
using ReceiptRewards.Domain.Repositories;
using ReceiptRewards.Infrastructure.DataAccess.Contexts;

namespace ReceiptRewards.Infrastructure.DataAccess.Repositories
{
    public class EventRepository : Repository<Event>, IEventRepository
    {
        public EventRepository(ReceiptRewardsAPIDbContext context) : base(context)
        {
        }
    }
}
