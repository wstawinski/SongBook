using SongBook.Domain.Models.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SongBook.Domain.Interfaces.Base
{
    public interface IManager<T> where T : ModelBase
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(long id);
        Task<T> Add(T model);
        Task<T> Update(T model);
        Task Remove(long id);
    }
}
