using System.Collections.Generic;

namespace SongBook.Domain.Models
{
    public class Line : BaseModel
    {
        public List<Word> Words { get; set; }
    }
}
