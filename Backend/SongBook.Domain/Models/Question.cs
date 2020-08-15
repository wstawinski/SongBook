using System.Collections.Generic;

namespace SongBook.Domain.Models
{
    public class Question : BaseModel
    {
        public long UserId { get; set; }
        public User User { get; set; }
        public string Content { get; set; }
        public List<Answer> Answers { get; set; }
    }
}
