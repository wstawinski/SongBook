using Microsoft.AspNetCore.Mvc;
using SongBook.Domain.Interfaces;
using SongBook.Domain.Models;

namespace SongBook.API.Controllers
{
    [Route("api/v1/Chord")]
    public class ChordController : BaseController<Chord, IChordManager>
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