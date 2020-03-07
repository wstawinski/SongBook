using SongBook.Domain.Interfaces.Base;
using SongBook.Domain.Models.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SongBook.Domain.Managers.Base
{
    public abstract class ManagerBase<T> : IManager<T> where T : ModelBase
    {
        protected readonly IRepository<T> Repository;

        public ManagerBase(IRepository<T> repository)
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

            var result = await Repository.GetByIdAsync(model.Id);

            return result;
        }

        public virtual async Task<T> Update(T model)
        {
            Repository.Update(model);

            await Repository.SaveChangesAsync();

            var result = await Repository.GetByIdAsync(model.Id);

            return result;
        }

        public virtual async Task Remove(long id)
        {
            Repository.Remove(id);

            await Repository.SaveChangesAsync();
        }
    }
}
