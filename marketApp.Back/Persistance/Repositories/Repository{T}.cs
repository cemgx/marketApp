using marketApp.Back.Core.Application.Interfaces;
using marketApp.Back.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Linq.Expressions;

namespace marketApp.Back.Persistance.Repositories
{
    public class Repository<T> : IRepository<T> where T : class, new()
    {
        private readonly JwtContext jwtContext;

        public Repository(JwtContext jwtContext)
        {
            this.jwtContext = jwtContext;
        }

        public async Task CreateAsync(T entity)
        {
            await this.jwtContext.Set<T>().AddAsync(entity);
            await this.jwtContext.SaveChangesAsync();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await this.jwtContext.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<T?> GetByFilterAsync(Expression<Func<T, bool>> filter)
        {
            return await this.jwtContext.Set<T>().AsNoTracking().SingleOrDefaultAsync(filter);
        }

        public async Task<T?> GetByIdAsync(object id)
        {
            return await this.jwtContext.Set<T>().FindAsync(id);
        }

        public async Task RemoveAsync(T entity)
        {
            this.jwtContext.Set<T>().Remove(entity);
            await this.jwtContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            this.jwtContext.Set<T>().Update(entity);
            await this.jwtContext.SaveChangesAsync();
        }
    }
}
