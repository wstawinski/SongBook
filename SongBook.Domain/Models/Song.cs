using SongBook.Domain.Models.Base;
using System.Collections.Generic;

namespace SongBook.Domain.Models
{
    public class Song : ModelBase
    {
        public Performer Performer { get; set; }
        public List<Paragraph> Paragraphs { get; set; }
        public Description PerformerDescription { get; set; }
        public Description UserDescription { get; set; }
    }
}
