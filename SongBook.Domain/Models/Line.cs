using SongBook.Domain.Models.Base;
using System.Collections.Generic;

namespace SongBook.Domain.Models
{
    public class Line : CollectionItemBase
    {
        public string Text { get; set; }
        public List<LineChord> LineChords { get; set; }
    }
}
