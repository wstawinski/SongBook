using Microsoft.AspNetCore.Mvc;
using SongBook.API.Controllers.Base;
using SongBook.Domain.Interfaces.Manager;
using SongBook.Domain.Models;
using System.Collections.Generic;

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
            return new Performer
            {
                Songs = new List<Song>
                {
                    new Song
                    {
                        Paragraphs = new List<Paragraph>
                        {
                            new Paragraph
                            {
                                Lines = new List<Line>
                                {
                                    new Line
                                    {
                                        LineChords = new List<LineChord>
                                        {
                                            new LineChord
                                            {
                                                Chord = new Chord()
                                            }
                                        }
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