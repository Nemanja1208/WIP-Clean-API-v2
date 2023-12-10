using Domain.Models.User;
using Infrastructure.Database.MySQLDatabase;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.UserAnimals
{
    public class UserAnimalRepository : IUserAnimalsRepository
    {
        private readonly RealDatabase _realDatabase;

        public UserAnimalRepository(RealDatabase realDatabase)
        {
            _realDatabase = realDatabase;
        }

        public async Task<List<UserModel>> GetAllUsersWithAnimals()
        {
            try
            {
                List<UserModel> allUsersWithAnimals = _realDatabase.Users.Include(u => u.UserAnimals).ToList();
                return await Task.FromResult(allUsersWithAnimals);
            }
            catch (ArgumentException e)
            {
                throw new ArgumentException(e.Message);
            }
        }
    }
}
