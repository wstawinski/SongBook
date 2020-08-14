using System.Collections.Generic;

namespace SongBook.Domain.Models
{
    public class Paragraph : BaseModel
    {
        public List<Line> Lines { get; set; }
    }
}
