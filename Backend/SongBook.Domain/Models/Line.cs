using System.Collections.Generic;

namespace SongBook.Domain.Models
{
    public class Line : BaseCollectionItem
    {
        public List<Word> Words { get; set; }
    }
}
