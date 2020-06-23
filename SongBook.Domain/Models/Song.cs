using System.Collections.Generic;

namespace SongBook.Domain.Models
{
    public class Song : ModelBase
    {
        public string Performer { get; set; }
        public string Title { get; set; }
        public List<Paragraph> Paragraphs { get; set; }
    }
}
