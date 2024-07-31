﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence;

#nullable disable

namespace Persistence.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.7");

            modelBuilder.Entity("Domain.Anime", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("AuthorFirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("AuthorLastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Animes");
                });

            modelBuilder.Entity("Domain.AnimeGenre", b =>
                {
                    b.Property<Guid>("AnimeId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("GenreId")
                        .HasColumnType("TEXT");

                    b.HasKey("AnimeId", "GenreId");

                    b.HasIndex("GenreId");

                    b.ToTable("AnimeGenres");
                });

            modelBuilder.Entity("Domain.Genre", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("Domain.AnimeGenre", b =>
                {
                    b.HasOne("Domain.Anime", "Anime")
                        .WithMany("Genres")
                        .HasForeignKey("AnimeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Genre", "Genre")
                        .WithMany("Animes")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Anime");

                    b.Navigation("Genre");
                });

            modelBuilder.Entity("Domain.Anime", b =>
                {
                    b.Navigation("Genres");
                });

            modelBuilder.Entity("Domain.Genre", b =>
                {
                    b.Navigation("Animes");
                });
#pragma warning restore 612, 618
        }
    }
}
