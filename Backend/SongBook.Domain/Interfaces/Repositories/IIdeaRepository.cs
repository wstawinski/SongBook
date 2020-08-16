using SongBook.Domain.Models;
using System.Threading.Tasks;

namespace SongBook.Domain.Interfaces
{
    public interface IIdeaRepository : IBaseRepository<Idea>
    {
        new Task Update(Idea model);
        Task RemoveNestedObjectsByUserId(long userId);
    }
}
