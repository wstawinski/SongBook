using SongBook.Domain.Interfaces;
using SongBook.Domain.Models;

namespace SongBook.Domain.Managers
{
    public class IdeaManager : BaseManager<Idea, IIdeaRepository>, IIdeaManager
    {
        public IdeaManager(IIdeaRepository repository) : base(repository)
        {
        }
    }
}
