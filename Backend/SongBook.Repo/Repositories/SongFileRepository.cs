using SongBook.Domain.Interfaces;
using SongBook.Domain.Models;

namespace SongBook.Repo.Repositories
{
    public class SongFileRepository : BaseRepository<SongFile>, ISongFileRepository
    {
        public SongFileRepository(SongBookDbContext dataContext): base(dataContext)
        {
        }
    }
}
