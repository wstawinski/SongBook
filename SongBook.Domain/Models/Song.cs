﻿using SongBook.Domain.Models.Base;
using System.Collections.Generic;

namespace SongBook.Domain.Models
{
    public class Song : ModelBase
    {
        public Performer Performer { get; set; }
        public string Title { get; set; }
        public List<Paragraph> Paragraphs { get; set; }
        public Description Description { get; set; }
    }
}
