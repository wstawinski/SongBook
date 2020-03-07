using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SongBook.Domain.Models;

namespace SongBook.Repo.Configurations
{
    class LineConfiguration : IEntityTypeConfiguration<Line>
    {
        public void Configure(EntityTypeBuilder<Line> builder)
        {
            builder.ToTable("Lines");
            builder.Ignore(l => l.IsDeleted);

            builder.HasMany(l => l.LineChords)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
