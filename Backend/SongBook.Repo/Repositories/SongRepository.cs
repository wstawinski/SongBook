using SongBook.Domain.Interfaces;
using SongBook.Domain.Models;

namespace SongBook.Repo.Repositories
{
    public class SongRepository : BaseRepository<Song>, ISongRepository
    {
        public SongRepository(SongBookDbContext dataContext) : base(dataContext)
        {
        }
    }
}
