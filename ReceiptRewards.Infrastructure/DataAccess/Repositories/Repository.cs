
using Microsoft.EntityFrameworkCore;
using ReceiptRewards.Domain.Repositories;
using ReceiptRewards.Infrastructure.DataAccess.Contexts;

using System.Linq.Expressions;


namespace ReceiptRewards.Infrastructure.DataAccess.Repositories;

public class Repository<T> : IRepository<T> where T : class
{
    protected readonly ReceiptRewardsAPIDbContext _context;
    public Repository(ReceiptRewardsAPIDbContext context)
    {
        _context = context;
    }
    public async Task AddAsync(T entity)
    {
        await _context.Set<T>().AddAsync(entity);
    }

    public async Task AddRange(List<T> entities)
    {
        foreach (var entity in entities)
        {
            _context.Set<T>().Add(entity);
        }
    }


    public async Task<IQueryable<T>> GetAllAsync(Expression<Func<T, bool>> expression, params string[] includes)
    {
        var query = _context.Set<T>().Where(expression);
        if (includes != null)
        {
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
        }
        return query;
    }

    public async Task<IQueryable<T>> GetAllAsync(params string[] includes)
    {
        var query = _context.Set<T>().AsQueryable();
        if (includes != null)
        {
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
        }
        return query;
    }

    public Task<IEnumerable<T>> GetAllAsync()
    {
        throw new NotImplementedException();
    }


    public async Task<T> GetAsync(Expression<Func<T, bool>> expression, params string[] includes)
    {
        var query = _context.Set<T>().Where(expression);
        if (includes != null)
        {
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
        }
        return await query.FirstOrDefaultAsync();
    }



    public async Task<bool> isExist(Expression<Func<T, bool>> expression)
    {
        return await _context.Set<T>().AnyAsync(expression);
    }

    public async Task Remove(T entity)
    {
        _context.Set<T>().Remove(entity);
    }

    public async Task RemoveRange(List<T> entities)
    {
        foreach (var entity in entities)
        {
            _context.Set<T>().Remove(entity);
        }
    }



    public async Task<int> SaveAsync()
    {
        return await _context.SaveChangesAsync();
    }
}
