using SongBook.Domain.Interfaces.Manager;
using SongBook.Domain.Interfaces.Repository;
using SongBook.Domain.Models;

namespace SongBook.Domain.Managers
{
    public class ChordManager : BaseManager<Chord, IChordRepository>, IChordManager
    {
        public ChordManager(IChordRepository repository) : base(repository)
        {
        }
    }
}
