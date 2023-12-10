using Application.Dtos.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.Animal
{
    public class AnimalDto
    {
        public Guid AnimalId { get; set; }
        public string? Name { get; set; }
        public List<UserDto>? Users { get; set; }
    }
}
