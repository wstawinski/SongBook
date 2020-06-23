namespace SongBook.Domain.Models
{
    public abstract class CollectionItemBase : ModelBase
    {
        public bool IsDeleted { get; set; }
        public int Number { get; set; }
    }
}
