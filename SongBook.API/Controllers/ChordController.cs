using Microsoft.AspNetCore.Mvc;
using SongBook.API.Controllers.Base;
using SongBook.Domain.Interfaces.Manager;
using SongBook.Domain.Models;

namespace SongBook.API.Controllers
{
    [Route("api/v1/Chord")]
    public class ChordController : AppControllerBase<Chord>
    {
        public ChordController(IChordManager manager) : base(manager)
        {
        }

        [HttpGet("GetEmpty")]
        public Chord GetEmpty()
        {
            return new Chord();
        }
    }
}