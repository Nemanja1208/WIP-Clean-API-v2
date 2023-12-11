using Application.Abstractions;
using Application.Dtos.Users;
using Domain.Models.User;


namespace Application.Commands.Users.Register
{
    public class RegisterUserCommand : ICommand<UserModel>
    {
        public RegisterUserCommand(UserCredentialsDto newUser)
        {
            NewUser = newUser;
        }

        public UserCredentialsDto NewUser { get; }
    }
}
