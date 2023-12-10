using Domain.Models.User;

namespace Infrastructure.Repositories.UserAnimals
{
    public interface IUserAnimalsRepository
    {
        Task<List<UserModel>> GetAllUsersWithAnimals();
    }
}
