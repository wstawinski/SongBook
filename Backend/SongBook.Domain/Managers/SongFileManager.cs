using SongBook.Domain.Interfaces;
using SongBook.Domain.Models;

namespace SongBook.Domain.Managers
{
    public class SongFileManager : BaseManager<SongFile, ISongFileRepository>, ISongFileManager
    {
        public SongFileManager(ISongFileRepository repository) : base(repository)
        {
        }
    }
}
