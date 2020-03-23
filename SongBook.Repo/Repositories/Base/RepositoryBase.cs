using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SongBook.Domain.Interfaces.Base;
using SongBook.Domain.Models.Base;

namespace SongBook.Repo.Repositories.Base
{
    public abstract class RepositoryBase<T> : IRepository<T> where T : ModelBase
    {
        protected readonly DbContext DataContext;

        public RepositoryBase(DbContext dataContext)
        {
            DataContext = dataContext;
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await DataContext.Set<T>().ToListAsync();
        }

        protected virtual T GetById(long id)
        {
            return DataContext.Set<T>().Find(id);
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
            DataContext.Add(model);
        }

        public virtual void Update(T model)
        {
            DataContext.Attach(model);

            DataContext.Update(model);

            UpdateCollections();
        }

        protected virtual void UpdateCollections()
        {
        }

        protected virtual void UpdateCollection<TItem>(IEnumerable<TItem> collection) where TItem : CollectionItemBase
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
            var model = GetById(id);

            if (model != null)
            {
                DataContext.Remove(model);
            }
        }

        public async Task<int> SaveChangesAsync()
        {
            return await DataContext.SaveChangesAsync();
        }
    }
}
