namespace SongBook.Domain.Models
{
    public class IdeaTeamMember : BaseModel
    {
        public long UserId { get; set; }
        public User User { get; set; }
        public int Rate { get; set; }
    }
}
