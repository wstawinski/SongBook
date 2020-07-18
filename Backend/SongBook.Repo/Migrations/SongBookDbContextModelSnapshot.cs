﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SongBook.Repo;

namespace SongBook.Repo.Migrations
{
    [DbContext(typeof(SongBookDbContext))]
    partial class SongBookDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SongBook.Domain.Models.Chord", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ChordSchema")
                        .HasColumnType("int");

                    b.Property<string>("Symbol")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Chords");
                });

            modelBuilder.Entity("SongBook.Domain.Models.Line", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<long?>("ParagraphId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ParagraphId");

                    b.ToTable("Lines");
                });

            modelBuilder.Entity("SongBook.Domain.Models.Paragraph", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<long?>("SongId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("SongId");

                    b.ToTable("Paragraphs");
                });

            modelBuilder.Entity("SongBook.Domain.Models.Song", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Performer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Songs");
                });

            modelBuilder.Entity("SongBook.Domain.Models.SongFile", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte[]>("FileData")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("FileName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ROWGUID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("SongFiles");
                });

            modelBuilder.Entity("SongBook.Domain.Models.Word", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("ChordId")
                        .HasColumnType("bigint");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<long?>("LineId")
                        .HasColumnType("bigint");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ChordId");

                    b.HasIndex("LineId");

                    b.ToTable("Words");
                });

            modelBuilder.Entity("SongBook.Domain.Models.Line", b =>
                {
                    b.HasOne("SongBook.Domain.Models.Paragraph", null)
                        .WithMany("Lines")
                        .HasForeignKey("ParagraphId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SongBook.Domain.Models.Paragraph", b =>
                {
                    b.HasOne("SongBook.Domain.Models.Song", null)
                        .WithMany("Paragraphs")
                        .HasForeignKey("SongId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SongBook.Domain.Models.Word", b =>
                {
                    b.HasOne("SongBook.Domain.Models.Chord", "Chord")
                        .WithMany()
                        .HasForeignKey("ChordId");

                    b.HasOne("SongBook.Domain.Models.Line", null)
                        .WithMany("Words")
                        .HasForeignKey("LineId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
