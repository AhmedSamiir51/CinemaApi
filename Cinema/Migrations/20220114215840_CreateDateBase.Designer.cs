﻿// <auto-generated />
using Cinema.Models.Date;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Cinema.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220114215840_CreateDateBase")]
    partial class CreateDateBase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Cinema.Models.Date.Booking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MovieId")
                        .IsUnique();

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Booking");
                });

            modelBuilder.Entity("Cinema.Models.Date.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("Cinema.Models.Date.Movies", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("Cinema.Models.Date.Movies_Cat", b =>
                {
                    b.Property<int>("MovieID")
                        .HasColumnType("int");

                    b.Property<int>("CatID")
                        .HasColumnType("int");

                    b.HasKey("MovieID", "CatID");

                    b.HasIndex("CatID")
                        .IsUnique();

                    b.HasIndex("MovieID")
                        .IsUnique();

                    b.ToTable("Movies_Cat");
                });

            modelBuilder.Entity("Cinema.Models.Date.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FristName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PhoneNumber")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Cinema.Models.Date.Booking", b =>
                {
                    b.HasOne("Cinema.Models.Date.Movies", "Movies")
                        .WithOne("Booking")
                        .HasForeignKey("Cinema.Models.Date.Booking", "MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Cinema.Models.Date.User", "User")
                        .WithOne("Booking")
                        .HasForeignKey("Cinema.Models.Date.Booking", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Movies");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Cinema.Models.Date.Movies_Cat", b =>
                {
                    b.HasOne("Cinema.Models.Date.Category", "Category")
                        .WithOne("Movies_Cat")
                        .HasForeignKey("Cinema.Models.Date.Movies_Cat", "CatID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Cinema.Models.Date.Movies", "Movies")
                        .WithOne("Movies_Cat")
                        .HasForeignKey("Cinema.Models.Date.Movies_Cat", "MovieID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Movies");
                });

            modelBuilder.Entity("Cinema.Models.Date.Category", b =>
                {
                    b.Navigation("Movies_Cat");
                });

            modelBuilder.Entity("Cinema.Models.Date.Movies", b =>
                {
                    b.Navigation("Booking");

                    b.Navigation("Movies_Cat");
                });

            modelBuilder.Entity("Cinema.Models.Date.User", b =>
                {
                    b.Navigation("Booking");
                });
#pragma warning restore 612, 618
        }
    }
}