namespace SongBook.Domain.Models
{
    public class Word : BaseModel
    {
        public string Text { get; set; }
        public Chord Chord { get; set; }
    }
}
