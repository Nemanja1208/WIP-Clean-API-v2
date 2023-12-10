using Application.Dtos.Animal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.Users
{
    public class UserDto
    {
        public Guid UserId { get; set; }
        public string? UserName { get; set; }
        public List<AnimalDto>? Animals { get; set; }
    }
}
