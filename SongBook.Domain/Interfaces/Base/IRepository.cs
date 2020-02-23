using SongBook.Domain.Models.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SongBook.Domain.Interfaces.Base
{
    public interface IRepository<T> where T : ModelBase
    {
        Task<IEnumerable<T>> GetAllAsync();
        T GetById(long id);
        Task<T> GetByIdAsync(long id);
        T Add(T model);
        T Update(T model);
        void Remove(long id);
        void SaveChanges();
    }
}
