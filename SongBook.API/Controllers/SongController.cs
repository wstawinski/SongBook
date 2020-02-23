﻿using Microsoft.AspNetCore.Mvc;
using SongBook.API.Controllers.Base;
using SongBook.Domain.Interfaces.Manager;
using SongBook.Domain.Models;
using System.Collections.Generic;

namespace SongBook.API.Controllers
{
    [Route("api/v1/Song")]
    public class SongController : AppControllerBase<Song>
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
            };
        }
    }
}
