using Microsoft.EntityFrameworkCore;
using REST_Test.Data.Data;
using System.Linq.Expressions;

namespace REST_Test.Model.Repositories
{
    public class GenericRepository<TEntity>: IGenericRepository<TEntity> where TEntity : class
    {
        internal RESTTestContext context;
        internal DbSet<TEntity> dbSet;

        public GenericRepository(RESTTestContext context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }

        public async Task CreateAsync(TEntity entity)
        {
            await dbSet.AddAsync(entity);
            await SaveAsync();
        }

        public async Task<List<TEntity>> GetAllAsync(bool tracked = true)
        {
            IQueryable<TEntity> query = dbSet;

            if (!tracked)
            {
                query = query.AsNoTracking();
            }

            return await query.ToListAsync();
        }

        public async Task<TEntity> GetAsync(int id, bool tracked = true)
        {
            return await dbSet.FindAsync(id);
        }

        public async Task UpdateAsync(TEntity entity)
        {
            dbSet.Update(entity);
            await SaveAsync();
        }

        public async Task RemoveAsync(TEntity entity)
        {
            var entityToDelete = await dbSet.FindAsync(entity);

            if (entityToDelete != null)
            {
                dbSet.Remove(entityToDelete);
                await SaveAsync();
            }
        }

        public async Task RemoveAsync(int id)
        {
            var entityToDelete = await dbSet.FindAsync(id);

            if (entityToDelete != null)
            {
                dbSet.Remove(entityToDelete);
                await SaveAsync();
            }
        }

        public async Task SaveAsync()
        {
            await context.SaveChangesAsync();
        }

    }
}
