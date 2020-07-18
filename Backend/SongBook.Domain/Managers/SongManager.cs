using SongBook.Domain.Interfaces;
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
