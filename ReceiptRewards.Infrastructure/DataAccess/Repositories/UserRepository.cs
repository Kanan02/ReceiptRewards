using ReceiptRewards.Domain.Entities;
using ReceiptRewards.Domain.Repositories;
using ReceiptRewards.Infrastructure.DataAccess.Contexts;

namespace ReceiptRewards.Infrastructure.DataAccess.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(ReceiptRewardsAPIDbContext context) : base(context)
        {
        }
    }
}
