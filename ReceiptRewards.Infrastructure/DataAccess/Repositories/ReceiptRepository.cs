using ReceiptRewards.Domain.Entities;
using ReceiptRewards.Domain.Repositories;
using ReceiptRewards.Infrastructure.DataAccess.Contexts;

namespace ReceiptRewards.Infrastructure.DataAccess.Repositories
{
    public class ReceiptRepository : Repository<Receipt>, IReceiptRepository
    {
        public ReceiptRepository(ReceiptRewardsAPIDbContext context) : base(context)
        {
        }
    }
}
