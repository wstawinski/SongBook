using SongBook.Domain.Interfaces;
using SongBook.Domain.Models;
using System.Threading.Tasks;

namespace SongBook.Domain.Managers
{
    public class IdeaManager : BaseManager<Idea, IIdeaRepository>, IIdeaManager
    {
        public IdeaManager(IIdeaRepository repository) : base(repository)
        {
        }

        public override async Task<Idea> Update(Idea model)
        {
            await Repository.Update(model);

            await Repository.SaveChangesAsync();

            return model;
        }

        public async Task RemoveNestedObjectsByUserId(long userId)
        {
            await Repository.RemoveNestedObjectsByUserId(userId);

            await Repository.SaveChangesAsync();
        }
    }
}
