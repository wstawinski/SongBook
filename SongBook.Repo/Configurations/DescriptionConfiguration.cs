using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SongBook.Domain.Models;

namespace SongBook.Repo.Configurations
{
    class DescriptionConfiguration : IEntityTypeConfiguration<Description>
    {
        public void Configure(EntityTypeBuilder<Description> builder)
        {
            builder.ToTable("Descriptions");
        }
    }
}
