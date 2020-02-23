using Microsoft.AspNetCore.Mvc;
using SongBook.API.Controllers.Base;
using SongBook.Domain.Interfaces.Manager;
using SongBook.Domain.Models;

namespace SongBook.API.Controllers
{
    [Route("api/v1/Performer")]
    public class PerformerController : AppControllerBase<Performer>
    {
        public PerformerController(IPerformerManager manager) : base(manager)
        {
        }

        [HttpGet("GetEmpty")]
        public Performer GetEmpty()
        {
            return new Performer();
        }
    }
}