using SongBook.Domain.Enums;

namespace SongBook.Domain.Models
{
    public class Chord : ModelBase
    {
        public string Symbol { get; set; }
        public ChordSchema ChordSchema { get; set; }
    }
}
