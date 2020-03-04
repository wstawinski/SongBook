﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SongBook.Domain.Models;

namespace SongBook.Repo.Configurations
{
    class PerformerConfiguration : IEntityTypeConfiguration<Performer>
    {
        public void Configure(EntityTypeBuilder<Performer> builder)
        {
            builder.ToTable("Performers");
            builder.HasKey(p => p.Id);
        }
    }
}
