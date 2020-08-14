using System.Collections.Generic;

namespace SongBook.Domain.Models
{
    public class Idea : BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public long UserId { get; set; }
        public User User { get; set; }
        public List<IdeaTeamMember> IdeaTeamMembers { get; set; }
        public List<Question> Questions { get; set; }
    }
}
