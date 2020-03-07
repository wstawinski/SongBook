using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SongBook.Domain.Models;

namespace SongBook.Repo.Configurations
{
    class LineChordConfiguration : IEntityTypeConfiguration<LineChord>
    {
        public void Configure(EntityTypeBuilder<LineChord> builder)
        {
            builder.ToTable("LineChords");
            builder.Ignore(lc => lc.IsDeleted);
        }
    }
}
