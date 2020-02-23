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

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await DataContext.Set<T>().ToListAsync();
        }

        public T GetById(long id)
        {
            return DataContext.Set<T>().Find(id);
        }

        public async Task<T> GetByIdAsync(long id)
        {
            return await DataContext.Set<T>().FindAsync(id);
        }

        public T Add(T model)
        {
            DataContext.Set<T>().Add(model);

            return model;
        }

        public T Update(T model)
        {
            DataContext.Set<T>().Update(model);

            return model;
        }

        public void Remove(long id)
        {
            var model = GetById(id);

            if (model != null)
            {
                DataContext.Set<T>().Remove(model);
            }
        }

        public void SaveChanges()
        {
            DataContext.SaveChanges();
        }
    }
}
