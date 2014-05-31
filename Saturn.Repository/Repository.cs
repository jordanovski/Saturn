using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Saturn.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbContext dbContext;

        public Repository(DbContext dbContext)
        {
            this.dbContext = dbContext;
            this.dbContext.Configuration.ProxyCreationEnabled = false;
        }

        public async Task<int> AddAsync(T t)
        {
            dbContext.Set<T>().Add(t);
            return await dbContext.SaveChangesAsync();
        }

        public async Task<int> RemoveAsync(T t)
        {
            dbContext.Entry(t).State = EntityState.Deleted;
            return await dbContext.SaveChangesAsync();
        }

        public async Task<int> UpdateAsync(T t)
        {
            dbContext.Entry(t).State = EntityState.Modified;
            return await dbContext.SaveChangesAsync();
        }

        public async Task<int> CountAsync()
        {
            return await dbContext.Set<T>().CountAsync();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await dbContext.Set<T>().ToListAsync();
        }

        public async Task<T> FindAsync(Expression<Func<T, bool>> match)
        {
            return await dbContext.Set<T>().SingleOrDefaultAsync(match);
        }

        public async Task<List<T>> FindAllAsync(Expression<Func<T, bool>> match)
        {
            return await dbContext.Set<T>().Where(match).ToListAsync();
        }
    }
}
