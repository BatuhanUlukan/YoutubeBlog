using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using YoutubeBlog.Core.Entities;
using YoutubeBlog.Data.Context;
using YoutubeBlog.Data.Repositories.Abstractions;

namespace YoutubeBlog.Data.Repositories.Concretes
{
    public class Repository<T> : IRepository<T> where T : class, IEntityBase, new()
    {
        private readonly AppDbContext dbContext;

        public Repository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        private DbSet<T> Table => dbContext.Set<T>();



        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = Table;

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            if (includeProperties.Any())
            {
                query = includeProperties.Aggregate(query, (current, include) => current.Include(include));
            }

            return await query.ToListAsync();
        }

        public async Task AddAsync(T entity)
        {
            await Table.AddAsync(entity);
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = Table;

            if (includeProperties.Any())
            {
                query = includeProperties.Aggregate(query, (current, include) => current.Include(include));
            }

            return await query.FirstOrDefaultAsync(predicate);
        }

        public async Task<T> GetByGuidAsync(Guid id)
        {
            return await Table.FindAsync(id);
        }

        public async Task<T> UpdateAsync(T entity)
        {
            Table.Update(entity);
            await dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            Table.RemoveRange(entity);
            await dbContext.SaveChangesAsync();

        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate)
        {
            return await Table.AnyAsync(predicate);
        }

        public async Task<int> CountAsync(Expression<Func<T, bool>> predicate = null)
        {
            if (predicate != null)
                return await Table.CountAsync(predicate);
            else
                return await Table.CountAsync();
        }
    }
}
