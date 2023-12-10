using Domain.Models;
using Domain.Models.Animal;
using Domain.Models.User;
using Domain.Models.UserAnimal;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database.DatabaseHelpers
{
    public static class DatabaseSeedHelper
    {
        public static void SeedData(ModelBuilder modelBuilder)
        {
            //SeedDogs(modelBuilder);
            SeedUsers_Animals_And_UserAnimals(modelBuilder);

            // Add more methods for other entities as needed
        }



        private static void SeedUsers_Animals_And_UserAnimals(ModelBuilder modelBuilder)
        {
            // UserModels
            var user1Id = Guid.NewGuid();
            var user2Id = Guid.NewGuid();
            var user3Id = Guid.NewGuid();

            modelBuilder.Entity<UserModel>().HasData(
                new UserModel { UserId = user1Id, UserName = "User1", UserPassword = "Password1" },
                new UserModel { UserId = user2Id, UserName = "User2", UserPassword = "Password2" },
                new UserModel { UserId = user3Id, UserName = "User3", UserPassword = "Password3" }
            );

            // AnimalModels
            var animal1Id = Guid.NewGuid();
            var animal2Id = Guid.NewGuid();
            var animal3Id = Guid.NewGuid();

            modelBuilder.Entity<AnimalModel>().HasData(
                new AnimalModel { AnimalId = animal1Id, Name = "Lion" },
                new AnimalModel { AnimalId = animal2Id, Name = "Tiger" },
                new AnimalModel { AnimalId = animal3Id, Name = "Elephant" }
            );

            //UserAnimalModels
            modelBuilder.Entity<UserAnimalModel>().HasData(
                new UserAnimalModel { UserId = user1Id, AnimalId = animal1Id },
                new UserAnimalModel { UserId = user1Id, AnimalId = animal2Id },
                new UserAnimalModel { UserId = user2Id, AnimalId = animal2Id },
                new UserAnimalModel { UserId = user3Id, AnimalId = animal3Id }
            );
        }

        private static void SeedDogs(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dog>().HasData(
                new Dog { AnimalId = Guid.NewGuid(), Name = "OldG" },
                new Dog { AnimalId = Guid.NewGuid(), Name = "NewG" },
                new Dog { AnimalId = Guid.NewGuid(), Name = "Björn" },
                new Dog { AnimalId = Guid.NewGuid(), Name = "Patrik" },
                new Dog { AnimalId = Guid.NewGuid(), Name = "Alfred" },
                new Dog { AnimalId = new Guid("12345678-1234-5678-1234-567812345671"), Name = "TestDogForUnitTests1" },
                new Dog { AnimalId = new Guid("12345678-1234-5678-1234-567812345672"), Name = "TestDogForUnitTests2" },
                new Dog { AnimalId = new Guid("12345678-1234-5678-1234-567812345673"), Name = "TestDogForUnitTests3" },
                new Dog { AnimalId = new Guid("12345678-1234-5678-1234-567812345674"), Name = "TestDogForUnitTests4" }
            );
        }
    }
}
