using SongBook.Domain.Interfaces.Repository;
using SongBook.Domain.Models;
using SongBook.Repo.Repositories.Base;

namespace SongBook.Repo.Repositories
{
    public class PerformerRepository : RepositoryBase<Performer>, IPerformerRepository
    {
        public PerformerRepository(SongBookDbContext dataContext) : base(dataContext)
        {
        }
    }
}
