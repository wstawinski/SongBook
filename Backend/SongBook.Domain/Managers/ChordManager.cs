using SongBook.Domain.Interfaces;
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
