
using System.Linq.Expressions;


namespace ReceiptRewards.Domain.Repositories
{
    public interface IRepository<T>
        where T : class
    {
        public Task AddAsync(T entities);

        public Task<IQueryable<T>> GetAllAsync(
            Expression<Func<T, bool>> expression,
            params string[] includes
        );
        public Task<IQueryable<T>> GetAllAsync(params string[] includes);
        public Task<T> GetAsync(Expression<Func<T, bool>> expression, params string[] includes);

        public Task Remove(T entities);
        public Task RemoveRange(List<T> entities);
        public Task AddRange(List<T> entities);

        public Task<int> SaveAsync();

        public Task<bool> isExist(Expression<Func<T, bool>> expression);
    }
}
