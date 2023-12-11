﻿using Application.Abstractions;
using Application.Exceptions;
using Application.Validators.User;
using Azure.Core;
using Domain.Models.User;
using Domain.Shared.Validations;
using Infrastructure.Repositories.Users;
using MediatR;
namespace Application.Commands.Users.Register
{
    public class RegisterUserCommandHandler : ICommandHandler<RegisterUserCommand, UserModel>
    {
        private readonly IUserRepository _userRepository;
        private readonly RegisterUserCommandValidator _validator;

        public RegisterUserCommandHandler(IUserRepository userRepository, RegisterUserCommandValidator validator)
        {
            _userRepository = userRepository;
            _validator = validator;
        }
        public async Task<Result<UserModel>> Handle(RegisterUserCommand command)
        {
            var registerCommandValidation = _validator.Validate(command);

            if (!registerCommandValidation.IsValid)
            {
                var allErrors = registerCommandValidation.Errors.ConvertAll(errors => errors.ErrorMessage);

                throw new ArgumentException("Registration error: " + string.Join("; ", allErrors));
            }

            // Here can we use something called AutoMapper, helps us convert Dtos to Domain Models...
            var userToCreate = new UserModel
            {
                UserId = Guid.NewGuid(),
                UserName = command.NewUser.Username,
                UserPassword = command.NewUser.Password,
            };

            var createdUser = await _userRepository.RegisterUser(userToCreate);

            var result = Result<UserModel>.Ok(createdUser);

            return result;
        }
    }
}


//public async Task<UserModel> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
//{
//    var registerCommandValidation = _validator.Validate(request);

//    if (!registerCommandValidation.IsValid)
//    {
//        var allErrors = registerCommandValidation.Errors.ConvertAll(errors => errors.ErrorMessage);

//        throw new ArgumentException("Registration error: " + string.Join("; ", allErrors));
//    }

//    // Here can we use something called AutoMapper, helps us convert Dtos to Domain Models...
//    var userToCreate = new UserModel
//    {
//        UserId = Guid.NewGuid(),
//        UserName = request.NewUser.Username,
//        UserPassword = request.NewUser.Password,
//    };

//    var createdUser = await _userRepository.RegisterUser(userToCreate);

//    return createdUser;
//}