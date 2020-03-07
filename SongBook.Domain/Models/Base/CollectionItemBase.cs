namespace SongBook.Domain.Models.Base
{
    public abstract class CollectionItemBase : ModelBase
    {
        public bool IsDeleted { get; set; }
        public int Number { get; set; }
    }
}
