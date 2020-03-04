using SongBook.Domain.Models.Base;

namespace SongBook.Domain.Models
{
    public class Description : ModelBase
    {
        public string Title { get; set; }
        public string Text { get; set; }
    }
}
