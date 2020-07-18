using SongBook.Domain.Interfaces;
using SongBook.Domain.Models;

namespace SongBook.Repo.Repositories
{
    public class ChordRepository : BaseRepository<Chord>, IChordRepository
    {
        public ChordRepository(SongBookDbContext dataContext) : base(dataContext)
        {
        }
    }
}
