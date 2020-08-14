using SongBook.Domain.Interfaces;
using SongBook.Domain.Models;

namespace SongBook.Repo.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(SongBookDbContext dbContext) : base(dbContext)
        {
        }
    }
}
