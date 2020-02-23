using SongBook.Domain.Enums;
using SongBook.Domain.Models.Base;

namespace SongBook.Domain.Models
{
    public class Chord : ModelBase
    {
        public string Symbol { get; set; }
        public ChordSchema ChordSchema { get; set; }
    }
}
