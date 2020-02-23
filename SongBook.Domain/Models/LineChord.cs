using SongBook.Domain.Models.Base;

namespace SongBook.Domain.Models
{
    public class LineChord : ModelBase
    {
        public bool IsDeleted { get; set; }
        public byte Number { get; set; }
        public Chord Chord { get; set; }
    }
}
