using SongBook.Domain.Interfaces.Repository;
using SongBook.Domain.Models;
using SongBook.Repo.Repositories.Base;

namespace SongBook.Repo.Repositories
{
    public class ChordRepository : RepositoryBase<Chord>, IChordRepository
    {
        public ChordRepository(SongBookDbContext dataContext) : base(dataContext)
        {
        }
    }
}
