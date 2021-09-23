using Microsoft.EntityFrameworkCore;
using MovieApp.Domain.DbModels;
using MovieApp.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApp.Domain
{
    public class MovieAppDbContext : DbContext
    {
        public MovieAppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Movie> Movies {get; set;}
        public DbSet<User> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>(
                entity =>
                {
                    entity.HasKey(entity => entity.Id);
                    entity.Property(entity => entity.Title)
                          .IsRequired()
                          .HasMaxLength(100);
                    entity.Property(entity => entity.Year)
                          .IsRequired();
                    entity.Property(entity => entity.Genre)
                          .IsRequired();

                    entity.HasData(
                        new Movie()
                        {
                            Id = 1,
                            Title = "The Shawshank Redemption",
                            Year = 1994,
                            Genre = Genre.Drama
                        },
                        new Movie()
                        {
                            Id = 2,
                            Title = "The Godfather",
                            Year = 1972,
                            Genre = Genre.Crime
                        },
                        new Movie()
                        {
                            Id = 3,
                            Title = "The Dark Knight",
                            Year = 2008,
                            Genre = Genre.Action
                        },
                        new Movie()
                        {
                            Id = 4,
                            Title = "The Lord of the Rings: The Return of the King",
                            Year = 2003,
                            Genre = Genre.Adventure
                        }

                        ); 

                });

            modelBuilder.Entity<User>(
                entity =>
                {
                    entity.HasKey(entity => entity.Id);
                    entity.Property(entity => entity.FullName)
                          .IsRequired()
                          .HasMaxLength(100);
                    entity.Property(entity => entity.Username)
                          .IsRequired()
                          .HasMaxLength(100);
                    entity.Property(entity => entity.Password)
                          .IsRequired()
                          .HasMaxLength(20);
                    entity.Property(entity => entity.Subscrition)
                          .IsRequired();

                    entity.HasData(
                        new User()
                        {
                            Id = 1,
                            FullName = "John Doe",
                            Username = "John_Doe",
                            Password = "Doe1234",
                            Subscrition = true
                        },
                        new User()
                        {
                            Id = 2,
                            FullName = "Bob Bobsky",
                            Username = "Bobski_AllStar",
                            Password = "AllStar1234",
                            Subscrition = true
                        },
                        new User()
                        {
                            Id = 3,
                            FullName = "Joe Jonson",
                            Username = "Joe_Jon",
                            Password = "password",
                            Subscrition = true
                        }
                        ); 
                });
        }
    }
}
