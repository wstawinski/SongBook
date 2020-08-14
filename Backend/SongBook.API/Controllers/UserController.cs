using Microsoft.AspNetCore.Mvc;
using SongBook.Domain.Interfaces;
using SongBook.Domain.Models;

namespace SongBook.API.Controllers
{
    [Route("api/v1/User")]
    public class UserController : BaseController<User, IUserManager>
    {
        public UserController(IUserManager manager) : base(manager)
        {
        }

        [HttpGet("GetEmpty")]
        public User GetEmpty() => new User();
    }
}
