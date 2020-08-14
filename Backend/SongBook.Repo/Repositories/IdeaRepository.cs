using SongBook.Domain.Interfaces;
using SongBook.Domain.Models;

namespace SongBook.Repo.Repositories
{
    public class IdeaRepository : BaseRepository<Idea>, IIdeaRepository
    {
        public IdeaRepository(SongBookDbContext dbContext) : base(dbContext)
        {
        }
    }
}
