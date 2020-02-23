using SongBook.Domain.Models.Base;
using System.Collections.Generic;

namespace SongBook.Domain.Models
{
    public class Line : ModelBase
    {
        public bool IsDeleted { get; set; }
        public byte Number { get; set; }
        public string Text { get; set; }
        public List<LineChord> LineChords { get; set; }
    }
}
