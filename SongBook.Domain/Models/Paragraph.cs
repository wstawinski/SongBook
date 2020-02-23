using SongBook.Domain.Enums;
using SongBook.Domain.Models.Base;
using System.Collections.Generic;

namespace SongBook.Domain.Models
{
    public class Paragraph : ModelBase
    {
        public bool IsDeleted { get; set; }
        public byte Number { get; set; }
        public ParagraphType Type { get; set; }
        public List<Line> Lines { get; set; }
    }
}
