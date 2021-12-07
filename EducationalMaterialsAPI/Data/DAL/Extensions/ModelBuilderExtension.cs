using EducationalMaterialsAPI.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace EducationalMaterialsAPI.Data.DAL.Extensions
{
    public static class ModelBuilderExtension
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            SeedAuthors(modelBuilder);
            SeedEduMaterialTypes(modelBuilder);
            SeedEduMaterials(modelBuilder);
            SeedReviews(modelBuilder);
            
        }

        private static void SeedReviews(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Review>().HasData(
                new Review
                {
                    Id = 1,
                    EduMaterialId = 1,
                    ReviewDescription = "This is some review",
                    ReviewPoints = 6
                },
                new Review
                {
                    Id = 2,
                    EduMaterialId = 1,
                    ReviewDescription = "This is some review",
                    ReviewPoints = 7
                },
                new Review
                {
                    Id = 3,
                    EduMaterialId = 1,
                    ReviewDescription = "This is some review",
                    ReviewPoints = 5
                },
                new Review
                {
                    Id = 4,
                    EduMaterialId = 1,
                    ReviewDescription = "This is some review",
                    ReviewPoints = 6
                },
                new Review
                {
                    Id = 5,
                    EduMaterialId = 1,
                    ReviewDescription = "This is some review",
                    ReviewPoints = 8
                });
        }

        private static void SeedAuthors(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>().HasData(
                new Author
                {
                    Id = 1,
                    Name = "Albert Einstein",
                    Description = "This is Albert Einstein himself."
                },
                new Author
                {
                    Id = 2,
                    Name = "Vera Rubin",
                    Description = "This is Vera Rubin herself."
                },
                new Author
                {
                    Id = 3,
                    Name = "Mikołaj Kopernik",
                    Description = "This is Mikołaj Kopernik himself."
                },
                new Author
                {
                    Id = 4,
                    Name = "Maria Skłodowska-Curie",
                    Description = "This is Maria Skłodowska-Curie herself."
                });
        }

        private static void SeedEduMaterials(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EduMaterial>().HasData(
                            new EduMaterial
                            {
                                Id = 1,
                                Title = "EF Core",
                                Description = "EF Core educational material description.",
                                Location = "www.wikipedia.com",
                                AuthorId = 1,
                                EduMaterialTypeId = 1,
                                PublishDate = new DateTime(2021, 11, 1)
                            },
                            new EduMaterial
                            {
                                Id = 2,
                                Title = "EF Core",
                                Description = "EF Core educational material description.",
                                Location = "www.wikipedia.com",
                                AuthorId = 1,
                                EduMaterialTypeId = 2,
                                PublishDate = new DateTime(2021, 11, 1)
                            },
                            new EduMaterial
                            {
                                Id = 3,
                                Title = "Bike riding",
                                Description = "Bike riding educational material description.",
                                Location = "www.wikipedia.com",
                                AuthorId = 2,
                                EduMaterialTypeId = 3,
                                PublishDate = new DateTime(2011, 1, 14)
                            },
                            new EduMaterial
                            {
                                Id = 4,
                                Title = "Design Patterns",
                                Description = "Design Patterns educational material description.",
                                Location = "www.wikipedia.com",
                                AuthorId = 3,
                                EduMaterialTypeId = 4,
                                PublishDate = new DateTime(2020, 1, 22)
                            },
                            new EduMaterial
                            {
                                Id = 5,
                                Title = "Origami Master",
                                Description = "Origami Master educational material description.",
                                Location = "www.wikipedia.com",
                                AuthorId = 4,
                                EduMaterialTypeId = 1,
                                PublishDate = new DateTime(1911, 5, 1)
                            }

                        );
        }

        private static void SeedEduMaterialTypes(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EduMaterialType>().HasData(
                            new EduMaterialType
                            {
                                Id = 1,
                                Name = "Video",
                                Definition = "Video material description"
                            },
                            new EduMaterialType
                            {
                                Id = 2,
                                Name = "Article",
                                Definition = "Article material description"
                            },
                            new EduMaterialType
                            {
                                Id = 3,
                                Name = "Excercise",
                                Definition = "Excercise material description"
                            },
                            new EduMaterialType
                            {
                                Id = 4,
                                Name = "Audio",
                                Definition = "Audio material description"
                            }
                        );
        }

    }   
}
