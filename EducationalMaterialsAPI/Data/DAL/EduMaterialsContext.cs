using EducationalMaterialsAPI.Data.DAL.Extensions;
using EducationalMaterialsAPI.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace EducationalMaterialsAPI.Data.DAL
{
    public class EduMaterialsContext : DbContext
    {
        public EduMaterialsContext(DbContextOptions<EduMaterialsContext> options) : base(options) { }

        public DbSet<EduMaterialType> EduMaterialTypes { get; set; }
        public DbSet<EduMaterial> EduMaterials { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Review> Reviews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();
        }
    }
}
