using SongBook.Domain.Interfaces;
using SongBook.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SongBook.Domain.Managers
{
    public abstract class BaseManager<T,R> : IBaseManager<T> where T : BaseModel where R : IBaseRepository<T>
    {
        protected readonly R Repository;

        public BaseManager(R repository)
        {
            Repository = repository;
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await Repository.GetAllAsync();
        }

        public virtual async Task<T> GetByIdAsync(long id)
        {
            return await Repository.GetByIdAsync(id);
        }

        public virtual async Task<T> Add(T model)
        {
            Repository.Add(model);

            await Repository.SaveChangesAsync();

            return model;
        }

        public virtual async Task<T> Update(T model)
        {
            Repository.Update(model);

            await Repository.SaveChangesAsync();

            return model;
        }

        public virtual async Task<T> Remove(long id)
        {
            var model = await Repository.GetByIdAsync(id);
            if (model == null)
            {
                return null;
            }

            Repository.Remove(model);

            await Repository.SaveChangesAsync();

            return model;
        }
    }
}
