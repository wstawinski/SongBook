namespace SongBook.Domain.Models
{
    public class Answer : BaseModel
    {
        public long UserId { get; set; }
        public User User { get; set; }
        public string Content { get; set; }
    }
}
