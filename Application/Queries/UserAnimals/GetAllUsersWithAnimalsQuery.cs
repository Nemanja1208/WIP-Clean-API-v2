using Domain.Models.User;
using MediatR;

namespace Application.Queries.UserAnimals
{
    public class GetAllUsersWithAnimalsQuery : IRequest<List<UserModel>>
    {
    }
}
