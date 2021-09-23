﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MovieApp.Domain;

namespace MovieApp.Domain.Migrations
{
    [DbContext(typeof(MovieAppDbContext))]
    partial class MovieAppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MovieApp.Domain.DbModels.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Genre")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Movies");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Genre = 5,
                            Title = "The Shawshank Redemption",
                            Year = 1994
                        },
                        new
                        {
                            Id = 2,
                            Genre = 3,
                            Title = "The Godfather",
                            Year = 1972
                        },
                        new
                        {
                            Id = 3,
                            Genre = 0,
                            Title = "The Dark Knight",
                            Year = 2008
                        },
                        new
                        {
                            Id = 4,
                            Genre = 1,
                            Title = "The Lord of the Rings: The Return of the King",
                            Year = 2003
                        });
                });

            modelBuilder.Entity("MovieApp.Domain.DbModels.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<bool>("Subscrition")
                        .HasColumnType("bit");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FullName = "John Doe",
                            Password = "Doe1234",
                            Subscrition = true,
                            Username = "John_Doe"
                        },
                        new
                        {
                            Id = 2,
                            FullName = "Bob Bobsky",
                            Password = "AllStar1234",
                            Subscrition = true,
                            Username = "Bobski_AllStar"
                        },
                        new
                        {
                            Id = 3,
                            FullName = "Joe Jonson",
                            Password = "password",
                            Subscrition = true,
                            Username = "Joe_Jon"
                        });
                });

            modelBuilder.Entity("MovieApp.Domain.DbModels.Movie", b =>
                {
                    b.HasOne("MovieApp.Domain.DbModels.User", null)
                        .WithMany("Movies")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("MovieApp.Domain.DbModels.User", b =>
                {
                    b.Navigation("Movies");
                });
#pragma warning restore 612, 618
        }
    }
}
