using Domain.Models;
using Domain.Models.Animal;
using Domain.Models.User;
using Domain.Models.UserAnimal;
using Infrastructure.Database.DatabaseHelpers;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database.MySQLDatabase
{
    public class RealDatabase : DbContext
    {
        public RealDatabase() { }
        public RealDatabase(DbContextOptions<RealDatabase> options) : base(options) { }

        public virtual DbSet<UserModel> Users { get; set; }

        public virtual DbSet<AnimalModel> Animals { get; set; }

        public virtual DbSet<UserAnimalModel> UserAnimals { get; set; }

        public virtual DbSet<Dog> Dogs { get; set; }

        // Do not really know why I have to keep this safe guard here but hell... Let it be until we find out why...
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=NM-FRONTEDGE\\SQLEXPRESS; Database=api_project_db; Trusted_Connection=true; TrustServerCertificate=true;");
        }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AnimalModel>()
            .HasKey(a => a.AnimalId);

            modelBuilder.Entity<UserModel>()
            .HasKey(u => u.UserId);

            modelBuilder.Entity<UserAnimalModel>()
            .HasKey(ua => new { ua.UserId, ua.AnimalId });

            modelBuilder.Entity<UserAnimalModel>()
                .HasOne(ua => ua.User)
                .WithMany(u => u.UserAnimals)
                .HasForeignKey(ua => ua.UserId);

            modelBuilder.Entity<UserAnimalModel>()
                .HasOne(ua => ua.Animal)
                .WithMany(a => a.UserAnimals)
                .HasForeignKey(ua => ua.AnimalId);

            // Call the SeedData method from the external class
            DatabaseSeedHelper.SeedData(modelBuilder);
        }
    }
}
