using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SongBook.Domain.Models;

namespace SongBook.Repo.Configurations
{
    public class SongConfiguration : IEntityTypeConfiguration<Song>
    {
        public void Configure(EntityTypeBuilder<Song> builder)
        {
            builder.ToTable("Songs");

            builder.HasMany(s => s.Paragraphs)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(s => s.Description)
                .WithOne()
                .HasForeignKey<Description>(d => d.Id);
        }
    }
}
