using SongBook.Domain.Interfaces.Manager;
using SongBook.Domain.Interfaces.Repository;
using SongBook.Domain.Managers.Base;
using SongBook.Domain.Models;

namespace SongBook.Domain.Managers
{
    public class ChordManager : ManagerBase<Chord>, IChordManager
    {
        public ChordManager(IChordRepository repository) : base(repository)
        {
        }
    }
}
