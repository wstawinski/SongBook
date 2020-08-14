using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SongBook.Domain.Interfaces;
using SongBook.Domain.Models;

namespace SongBook.Repo.Repositories
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : BaseModel
    {
        protected readonly DbContext DataContext;

        public BaseRepository(DbContext dataContext)
        {
            DataContext = dataContext;
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await DataContext.Set<T>().ToListAsync();
        }

        public virtual async Task<T> GetByIdAsync(long id)
        {
            return await DataContext.Set<T>().FindAsync(id);
        }

        public virtual void Add(T model)
        {
            DataContext.Add(model);
        }

        public virtual void Update(T model)
        {
            DataContext.Update(model);
        }

        public virtual void Remove(T model)
        {
            DataContext.Remove(model);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await DataContext.SaveChangesAsync();
        }
    }
}
