using SongBook.Domain.Interfaces;
using SongBook.Domain.Models;
using System.Threading.Tasks;

namespace SongBook.Domain.Managers
{
    public class UserManager : BaseManager<User, IUserRepository>, IUserManager
    {
        private readonly IIdeaRepository _ideaRepository;

        public UserManager(IUserRepository repository, IIdeaRepository ideaRepository) : base(repository)
        {
            _ideaRepository = ideaRepository;
        }

        public override async Task<User> Remove(long id)
        {
            var user = await Repository.GetByIdAsync(id);
            if (user == null)
            {
                return null;
            }

            await _ideaRepository.RemoveNestedObjectsByUserId(user.Id);

            Repository.Remove(user);

            await Repository.SaveChangesAsync();

            return user;
        }
    }
}
