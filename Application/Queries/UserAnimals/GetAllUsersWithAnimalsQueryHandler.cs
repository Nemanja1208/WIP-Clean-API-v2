using Domain.Models.User;
using Infrastructure.Repositories.UserAnimals;
using MediatR;


namespace Application.Queries.UserAnimals
{
    internal sealed class GetAllUsersWithAnimalsQueryHandler : IRequestHandler<GetAllUsersWithAnimalsQuery, List<UserModel>>
    {
        private readonly IUserAnimalsRepository _userAnimalsRepository;

        public GetAllUsersWithAnimalsQueryHandler(IUserAnimalsRepository userAnimalRepository)
        {
            _userAnimalsRepository = userAnimalRepository;
        }

        public Task<List<UserModel>> Handle(GetAllUsersWithAnimalsQuery request, CancellationToken cancellationToken)
        {
            var allUsersWithAnimals = _userAnimalsRepository.GetAllUsersWithAnimals();

            return allUsersWithAnimals;
        }
    }
}
