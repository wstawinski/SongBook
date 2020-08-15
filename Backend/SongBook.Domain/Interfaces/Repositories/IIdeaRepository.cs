using SongBook.Domain.Models;
using System.Threading.Tasks;

namespace SongBook.Domain.Interfaces
{
    public interface IIdeaRepository : IBaseRepository<Idea>
    {
        Task RemoveNestedObjectsByUserId(long userId);
    }
}
