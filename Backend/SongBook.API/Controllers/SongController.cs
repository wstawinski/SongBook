using Microsoft.AspNetCore.Mvc;
using SongBook.Domain.Interfaces;
using SongBook.Domain.Models;
using System.Collections.Generic;

namespace SongBook.API.Controllers
{
    [Route("api/v1/Song")]
    public class SongController : BaseController<Song, ISongManager>
    {
        public SongController(ISongManager manager) : base(manager)
        {
        }

        [HttpGet("GetEmpty")]
        public Song GetEmpty()
        {
            return new Song
            {
                Paragraphs = new List<Paragraph>
                {
                    new Paragraph
                    {
                        Lines = new List<Line>
                        {
                            new Line
                            {
                                Words = new List<Word>
                                {
                                    new Word
                                    {
                                        Chord = new Chord()
                                    }
                                }
                            }
                        }
                    }
                }
            };
        }
    }
}
