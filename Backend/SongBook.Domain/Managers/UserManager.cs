using SongBook.Domain.Interfaces;
using SongBook.Domain.Models;

namespace SongBook.Domain.Managers
{
    public class UserManager : BaseManager<User, IUserRepository>, IUserManager
    {
        public UserManager(IUserRepository repository) : base(repository)
        {
        }
    }
}
