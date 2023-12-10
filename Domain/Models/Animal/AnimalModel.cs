using Domain.Models.User;
using Domain.Models.UserAnimal;

namespace Domain.Models.Animal
{
    public class AnimalModel
    {
        public Guid AnimalId { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<UserAnimalModel> UserAnimals { get; set; } = new List<UserAnimalModel>();
    }
}
