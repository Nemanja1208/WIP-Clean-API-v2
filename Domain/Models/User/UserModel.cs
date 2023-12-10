using Domain.Models.Animal;
using Domain.Models.UserAnimal;

namespace Domain.Models.User
{
    public class UserModel
    {
        public Guid UserId { get; set; }
        public required string UserName { get; set; }
        public required string UserPassword { get; set; }

        public List<UserAnimalModel> UserAnimals { get; set; } = new List<UserAnimalModel>();
    }
}
