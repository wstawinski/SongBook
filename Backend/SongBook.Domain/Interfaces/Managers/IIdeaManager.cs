using SongBook.Domain.Models;
using System.Threading.Tasks;

namespace SongBook.Domain.Interfaces
{
    public interface IIdeaManager : IBaseManager<Idea>
    {
        Task RemoveNestedObjectsByUserId(long userId);
    }
}
