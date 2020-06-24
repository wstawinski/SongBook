using System.Collections.Generic;

namespace SongBook.Domain.Models
{
    public class Paragraph : CollectionItemBase
    {
        public List<Line> Lines { get; set; }
    }
}
