using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SongBook.Domain.Models;

namespace SongBook.Repo.Configurations
{
    class ParagraphConfiguration : IEntityTypeConfiguration<Paragraph>
    {
        public void Configure(EntityTypeBuilder<Paragraph> builder)
        {
            builder.ToTable("Paragraphs");
            builder.Ignore(c => c.IsDeleted);

            builder.HasMany(c => c.Lines)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
