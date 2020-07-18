namespace SongBook.Domain.Models
{
    public class Word : BaseCollectionItem
    {
        public string Text { get; set; }
        public Chord Chord { get; set; }
    }
}
