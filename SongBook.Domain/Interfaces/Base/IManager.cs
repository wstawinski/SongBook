using SongBook.Domain.Models.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SongBook.Domain.Interfaces.Base
{
    public interface IManager<T> where T : ModelBase
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(long id);
        T Add(T model);
        T Update(T model);
        void Remove(long id);
    }
}
