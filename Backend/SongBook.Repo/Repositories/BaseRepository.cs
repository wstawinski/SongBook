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

        public virtual async Task<T> GetByIdAsync(long id, string[] includes)
        {
            var query = DataContext.Set<T>().AsQueryable();

            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }

            return await query.FirstOrDefaultAsync(m => m.Id == id);
        }

        public virtual void Add(T model)
        {
            if (model != null)
            {
                DataContext.Add(model);
            }
        }

        public virtual void Update(T model)
        {
            if (model != null)
            {
                DataContext.Attach(model);

                DataContext.Update(model);

                UpdateCollections();
            }
        }

        protected virtual void UpdateCollections()
        {
        }

        protected virtual void UpdateCollection<TItem>(IEnumerable<TItem> collection) where TItem : BaseCollectionItem
        {
            if (collection != null)
            {
                foreach (var item in collection)
                {
                    if (item.IsDeleted)
                    {
                        if (item.Id > 0)
                        {
                            DataContext.Remove(item);
                        }
                    }
                    else
                    {
                        DataContext.Update(item);
                    }
                }
            }
        }

        public virtual void Remove(long id)
        {
            DataContext.Remove(id);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await DataContext.SaveChangesAsync();
        }
    }
}
