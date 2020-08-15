using Microsoft.EntityFrameworkCore;
using SongBook.Domain.Interfaces;
using SongBook.Domain.Models;
using System.Linq;
using System.Threading.Tasks;

namespace SongBook.Repo.Repositories
{
    public class IdeaRepository : BaseRepository<Idea>, IIdeaRepository
    {
        public IdeaRepository(SongBookDbContext dataContext) : base(dataContext)
        {
        }

        public async Task RemoveNestedObjectsByUserId(long userId)
        {
            var ideaTeamMembers = await DataContext.Set<IdeaTeamMember>()
                .Where(i => i.UserId == userId)
                .ToListAsync();
            var questions = await DataContext.Set<Question>()
                .Where(i => i.UserId == userId)
                .ToListAsync();
            var answers = await DataContext.Set<Answer>()
                .Where(i => i.UserId == userId)
                .ToListAsync();

            DataContext.RemoveRange(ideaTeamMembers);
            DataContext.RemoveRange(questions);
            DataContext.RemoveRange(answers);
        }
    }
}
