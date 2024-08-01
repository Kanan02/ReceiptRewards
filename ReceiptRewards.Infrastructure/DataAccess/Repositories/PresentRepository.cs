using ReceiptRewards.Domain.Entities;
using ReceiptRewards.Domain.Repositories;
using ReceiptRewards.Infrastructure.DataAccess.Contexts;

namespace ReceiptRewards.Infrastructure.DataAccess.Repositories
{
    public class PresentRepository : Repository<Present>, IPresentRepository
    {
        public PresentRepository(ReceiptRewardsAPIDbContext context) : base(context)
        {
        }
    }
}
