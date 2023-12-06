using Domain.Models;
using Domain.Models.User;
using Infrastructure.Database.DatabaseHelpers;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database.MySQLDatabase
{
    public class RealDatabase : DbContext
    {
        public RealDatabase() { }
        public RealDatabase(DbContextOptions<RealDatabase> options) : base(options) { }

        public virtual DbSet<UserModel> Users { get; set; }
        public virtual DbSet<Dog> Dogs { get; set; }

        // Do not really know why I have to keep this safe guard here but hell... Let it be until we find out why...
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("connectionString");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Call the SeedData method from the external class
            DatabaseSeedHelper.SeedData(modelBuilder);
        }
    }
}
