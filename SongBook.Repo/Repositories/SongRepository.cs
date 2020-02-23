using SongBook.Domain.Interfaces.Repository;
using SongBook.Domain.Models;
using SongBook.Repo.Repositories.Base;

namespace SongBook.Repo.Repositories
{
    public class SongRepository : RepositoryBase<Song>, ISongRepository
    {
        public SongRepository(SongBookDbContext dataContext) : base(dataContext)
        {
        }
    }
}
