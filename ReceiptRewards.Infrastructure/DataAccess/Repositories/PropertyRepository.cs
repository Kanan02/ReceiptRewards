using ReceiptRewards.Domain.Entities;
using ReceiptRewards.Domain.Repositories;
using ReceiptRewards.Infrastructure.DataAccess.Contexts;

namespace ReceiptRewards.Infrastructure.DataAccess.Repositories
{
    public class PropertyRepository : Repository<AdditionalProperty>, IPropertyRepository
    {
        public PropertyRepository(ReceiptRewardsAPIDbContext context) : base(context)
        {
        }
    }
}
