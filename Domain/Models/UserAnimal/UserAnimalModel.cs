using Domain.Models.Animal;
using Domain.Models.User;
using System.Reflection.Emit;

namespace Domain.Models.UserAnimal
{
    public class UserAnimalModel
    {
        public Guid UserId { get; set; }
        public UserModel? User { get; set; }

        public Guid AnimalId { get; set; }

        public AnimalModel? Animal { get; set; }
    }
}
