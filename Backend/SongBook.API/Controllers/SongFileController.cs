using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SongBook.Domain.Interfaces;
using SongBook.Domain.Models;
using System;
using System.IO;
using System.Threading.Tasks;

namespace SongBook.API.Controllers
{
    [Route("api/v1/SongFile")]
    public class SongFileController : ControllerBase
    {
        private readonly ISongFileManager _songFileManager;

        public SongFileController(ISongFileManager songFileManager)
        {
            _songFileManager = songFileManager;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFile(long id)
        {
            var songFile = await _songFileManager.GetByIdAsync(id);
            if (songFile == null)
            {
                return BadRequest();
            }

            var memoryStream = new MemoryStream(songFile.FileData);

            return File(memoryStream, "application/octet-stream", songFile.FileName);
        }

        [HttpPost]
        public async Task<ActionResult> UploadFile([FromForm]IFormFile file)
        {
            using var fileStream = file.OpenReadStream();
            using var memoryStream = new MemoryStream();

            await fileStream.CopyToAsync(memoryStream);

            var songFile = new SongFile
            {
                FileName = file.FileName,
                FileData = memoryStream.ToArray()
            };

            var result = await _songFileManager.Add(songFile);
            if (result == null)
            {
                return BadRequest();
            }

            return Ok(result);
        }
    }
}
