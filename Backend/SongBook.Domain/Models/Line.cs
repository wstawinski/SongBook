using System.Collections.Generic;

namespace SongBook.Domain.Models
{
    public class Line : CollectionItemBase
    {
        public List<Word> Words { get; set; }
    }
}
