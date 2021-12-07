﻿// <auto-generated />
using System;
using EducationalMaterialsAPI.Data.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EducationalMaterialsAPI.Migrations
{
    [DbContext(typeof(EduMaterialsContext))]
    partial class EduMaterialsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("EducationalMaterialsAPI.Model.Entities.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Authors");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "This is Albert Einstein himself.",
                            Name = "Albert Einstein"
                        },
                        new
                        {
                            Id = 2,
                            Description = "This is Vera Rubin herself.",
                            Name = "Vera Rubin"
                        },
                        new
                        {
                            Id = 3,
                            Description = "This is Mikołaj Kopernik himself.",
                            Name = "Mikołaj Kopernik"
                        },
                        new
                        {
                            Id = 4,
                            Description = "This is Maria Skłodowska-Curie herself.",
                            Name = "Maria Skłodowska-Curie"
                        });
                });

            modelBuilder.Entity("EducationalMaterialsAPI.Model.Entities.EduMaterial", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EduMaterialTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("PublishDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("EduMaterialTypeId");

                    b.ToTable("EduMaterials");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AuthorId = 1,
                            Description = "EF Core educational material description.",
                            EduMaterialTypeId = 1,
                            Location = "www.wikipedia.com",
                            PublishDate = new DateTime(2021, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "EF Core"
                        },
                        new
                        {
                            Id = 2,
                            AuthorId = 1,
                            Description = "EF Core educational material description.",
                            EduMaterialTypeId = 2,
                            Location = "www.wikipedia.com",
                            PublishDate = new DateTime(2021, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "EF Core"
                        },
                        new
                        {
                            Id = 3,
                            AuthorId = 2,
                            Description = "Bike riding educational material description.",
                            EduMaterialTypeId = 3,
                            Location = "www.wikipedia.com",
                            PublishDate = new DateTime(2011, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Bike riding"
                        },
                        new
                        {
                            Id = 4,
                            AuthorId = 3,
                            Description = "Design Patterns educational material description.",
                            EduMaterialTypeId = 4,
                            Location = "www.wikipedia.com",
                            PublishDate = new DateTime(2020, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Design Patterns"
                        },
                        new
                        {
                            Id = 5,
                            AuthorId = 4,
                            Description = "Origami Master educational material description.",
                            EduMaterialTypeId = 1,
                            Location = "www.wikipedia.com",
                            PublishDate = new DateTime(1911, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Origami Master"
                        });
                });

            modelBuilder.Entity("EducationalMaterialsAPI.Model.Entities.EduMaterialType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Definition")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("EduMaterialTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Definition = "Video material description",
                            Name = "Video"
                        },
                        new
                        {
                            Id = 2,
                            Definition = "Article material description",
                            Name = "Article"
                        },
                        new
                        {
                            Id = 3,
                            Definition = "Excercise material description",
                            Name = "Excercise"
                        },
                        new
                        {
                            Id = 4,
                            Definition = "Audio material description",
                            Name = "Audio"
                        });
                });

            modelBuilder.Entity("EducationalMaterialsAPI.Model.Entities.Review", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("EduMaterialId")
                        .HasColumnType("int");

                    b.Property<string>("ReviewDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ReviewPoints")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EduMaterialId");

                    b.ToTable("Reviews");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            EduMaterialId = 1,
                            ReviewDescription = "This is some review",
                            ReviewPoints = 6
                        },
                        new
                        {
                            Id = 2,
                            EduMaterialId = 1,
                            ReviewDescription = "This is some review",
                            ReviewPoints = 7
                        },
                        new
                        {
                            Id = 3,
                            EduMaterialId = 1,
                            ReviewDescription = "This is some review",
                            ReviewPoints = 5
                        },
                        new
                        {
                            Id = 4,
                            EduMaterialId = 1,
                            ReviewDescription = "This is some review",
                            ReviewPoints = 6
                        },
                        new
                        {
                            Id = 5,
                            EduMaterialId = 1,
                            ReviewDescription = "This is some review",
                            ReviewPoints = 8
                        });
                });

            modelBuilder.Entity("EducationalMaterialsAPI.Model.Entities.EduMaterial", b =>
                {
                    b.HasOne("EducationalMaterialsAPI.Model.Entities.Author", "Author")
                        .WithMany("EduMaterials")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EducationalMaterialsAPI.Model.Entities.EduMaterialType", "EduMaterialType")
                        .WithMany("EduMaterials")
                        .HasForeignKey("EduMaterialTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("EduMaterialType");
                });

            modelBuilder.Entity("EducationalMaterialsAPI.Model.Entities.Review", b =>
                {
                    b.HasOne("EducationalMaterialsAPI.Model.Entities.EduMaterial", "EduMaterial")
                        .WithMany("Reviews")
                        .HasForeignKey("EduMaterialId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EduMaterial");
                });

            modelBuilder.Entity("EducationalMaterialsAPI.Model.Entities.Author", b =>
                {
                    b.Navigation("EduMaterials");
                });

            modelBuilder.Entity("EducationalMaterialsAPI.Model.Entities.EduMaterial", b =>
                {
                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("EducationalMaterialsAPI.Model.Entities.EduMaterialType", b =>
                {
                    b.Navigation("EduMaterials");
                });
#pragma warning restore 612, 618
        }
    }
}