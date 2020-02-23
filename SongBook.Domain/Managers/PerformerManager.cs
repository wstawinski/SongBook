using SongBook.Domain.Interfaces.Manager;
using SongBook.Domain.Interfaces.Repository;
using SongBook.Domain.Managers.Base;
using SongBook.Domain.Models;

namespace SongBook.Domain.Managers
{
    public class PerformerManager : ManagerBase<Performer>, IPerformerManager
    {
        public PerformerManager(IPerformerRepository repository) : base(repository)
        {
        }
    }
}
