using SongBook.Domain.Enums;

namespace SongBook.Domain.Models
{
    public class Chord : BaseModel
    {
        public string Symbol { get; set; }
        public ChordSchema ChordSchema { get; set; }
    }
}
