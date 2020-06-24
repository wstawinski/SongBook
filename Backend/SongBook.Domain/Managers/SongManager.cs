using SongBook.Domain.Interfaces.Manager;
using SongBook.Domain.Interfaces.Repository;
using SongBook.Domain.Models;

namespace SongBook.Domain.Managers
{
    public class SongManager : BaseManager<Song, ISongRepository>, ISongManager
    {
        public SongManager(ISongRepository repository) : base(repository)
        {
        }
    }
}
