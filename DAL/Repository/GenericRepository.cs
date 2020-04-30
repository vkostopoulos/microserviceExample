using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        private DatabaseContext databaseContext;

        public GenericRepository()
        {
            databaseContext = new DatabaseContext();
        }

        public async Task DeleteAsync(T entity)
        {
            databaseContext.Set<T>().Remove(entity);
            await databaseContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await databaseContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await databaseContext.Set<T>().FindAsync(id);
        }

        public async Task InsertAsync(T entity)
        {
            await databaseContext.Set<T>().AddAsync(entity);
            await databaseContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            databaseContext.Set<T>().Update(entity);
            await databaseContext.SaveChangesAsync();
        }
    }
}
