using SongBook.Domain.Interfaces.Repository;
using SongBook.Domain.Models;
using SongBook.Repo.Repositories.Base;
using System.Threading.Tasks;

namespace SongBook.Repo.Repositories
{
    public class PerformerRepository : RepositoryBase<Performer>, IPerformerRepository
    {
        public PerformerRepository(SongBookDbContext dataContext) : base(dataContext)
        {
        }

        public override async Task<Performer> GetByIdAsync(long id)
        {
            return await GetByIdAsync(id, new string[] { nameof(Performer.Songs)} );
        }
    }
}
