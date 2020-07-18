using SongBook.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SongBook.Domain.Interfaces
{
    public interface IBaseRepository<T> where T : BaseModel
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(long id);
        Task<T> GetByIdAsync(long id, string[] includes);
        void Add(T model);
        void Update(T model);
        void Remove(long id);
        Task<int> SaveChangesAsync();
    }
}
