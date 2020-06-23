namespace SongBook.Domain.Models
{
    public class Word : CollectionItemBase
    {
        public string Text { get; set; }
        public Chord Chord { get; set; }
    }
}
