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

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await Repository.GetAllAsync();
        }

        public async Task<T> GetByIdAsync(long id)
        {
            return await Repository.GetByIdAsync(id);
        }

        public T Add(T model)
        {
            var result = Repository.Add(model);

            Repository.SaveChanges();

            return result;
        }

        public T Update(T model)
        {
            var result = Repository.Update(model);

            Repository.SaveChanges();

            return result;
        }

        public void Remove(long id)
        {
            Repository.Remove(id);

            Repository.SaveChanges();
        }
    }
}
