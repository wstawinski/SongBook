using SongBook.Domain.Interfaces;
using SongBook.Domain.Models;
using System.Threading.Tasks;
using System.Transactions;

namespace SongBook.Domain.Managers
{
    public class UserManager : BaseManager<User, IUserRepository>, IUserManager
    {
        private readonly IIdeaManager _ideaManager;

        public UserManager(IUserRepository repository, IIdeaManager ideaManager) : base(repository)
        {
            _ideaManager = ideaManager;
        }

        public override async Task<User> Remove(long id)
        {
            var user = await Repository.GetByIdAsync(id);
            if (user == null)
            {
                return null;
            }

            using var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);

            await _ideaManager.RemoveNestedObjectsByUserId(user.Id);

            Repository.Remove(user);

            await Repository.SaveChangesAsync();

            scope.Complete();

            return user;
        }
    }
}
