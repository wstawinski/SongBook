using System.Collections.Generic;

namespace SongBook.Domain.Models
{
    public class Paragraph : BaseCollectionItem
    {
        public List<Line> Lines { get; set; }
    }
}
