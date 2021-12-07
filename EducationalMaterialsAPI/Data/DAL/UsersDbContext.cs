using EducationalMaterialsAPI.Model.User;
using Microsoft.EntityFrameworkCore;

namespace EducationalMaterialsAPI.Data.DAL
{
    public class UsersDbContext : DbContext
    {
        public UsersDbContext(DbContextOptions<UsersDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Seed();
        }
    }
}
