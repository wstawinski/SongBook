using SongBook.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SongBook.Domain.Interfaces
{
    public interface IBaseManager<T> where T : ModelBase
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(long id);
        Task<T> Add(T model);
        Task<T> Update(T model);
        Task<T> Remove(long id);
    }
}
