using ReceiptRewards.Domain.Entities;
using ReceiptRewards.Domain.Repositories;
using ReceiptRewards.Infrastructure.DataAccess.Contexts;

namespace ReceiptRewards.Infrastructure.DataAccess.Repositories;

public class LogRepository : Repository<ErrorLog>, ILogRepository
{
    public LogRepository(ReceiptRewardsAPIDbContext context) : base(context)
    {
    }
}