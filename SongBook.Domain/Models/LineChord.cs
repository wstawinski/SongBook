using SongBook.Domain.Models.Base;

namespace SongBook.Domain.Models
{
    public class LineChord : CollectionItemBase
    {
        public Chord Chord { get; set; }
    }
}
