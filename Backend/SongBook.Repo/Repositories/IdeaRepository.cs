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

        public override async Task<Idea> GetByIdAsync(long id)
        {
            var idea = await DataContext.Set<Idea>()
                .Include(i => i.IdeaTeamMembers)
                    .ThenInclude(i => i.User)
                .Include(i => i.Questions)
                    .ThenInclude(q => q.User)
                .Include(i => i.Questions)
                    .ThenInclude(q => q.Answers)
                        .ThenInclude(a => a.User)
                .FirstOrDefaultAsync(i => i.Id == id);

            return idea;
        }

        public override void Add(Idea model)
        {
            DataContext.Set<Idea>().Attach(model);

            DataContext.Set<Idea>().Add(model);

            foreach (var itm in model.IdeaTeamMembers)
            {
                DataContext.Set<IdeaTeamMember>().Add(itm);
            }
            foreach (var question in model.Questions)
            {
                DataContext.Set<Question>().Add(question);
            }
        }

        new public async Task Update(Idea model)
        {
            DataContext.Set<Idea>().Attach(model);

            DataContext.Set<Idea>().Update(model);

            foreach (var itm in model.IdeaTeamMembers)
            {
                DataContext.Set<IdeaTeamMember>().Update(itm);
            }
            foreach (var question in model.Questions)
            {
                DataContext.Set<Question>().Update(question);
            }

            var ideaTeamMembersToDelete = await DataContext.Set<Idea>()
                .Include(i => i.IdeaTeamMembers)
                .Where(i => i.Id == model.Id)
                .SelectMany(i => i.IdeaTeamMembers)
                .Where(i => !model.IdeaTeamMembers.Select(itm => itm.Id).Contains(i.Id))
                .ToListAsync();
            var questionsToDelete = await DataContext.Set<Idea>()
                .Include(i => i.Questions)
                .Where(i => i.Id == model.Id)
                .SelectMany(i => i.Questions)
                .Where(q => !model.Questions.Select(question => question.Id).Contains(q.Id))
                .ToListAsync();

            DataContext.RemoveRange(ideaTeamMembersToDelete);
            DataContext.RemoveRange(questionsToDelete);
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
