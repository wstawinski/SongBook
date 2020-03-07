using SongBook.Domain.Enums;
using SongBook.Domain.Models.Base;
using System.Collections.Generic;

namespace SongBook.Domain.Models
{
    public class Paragraph : CollectionItemBase
    {
        public ParagraphType Type { get; set; }
        public List<Line> Lines { get; set; }
    }
}
