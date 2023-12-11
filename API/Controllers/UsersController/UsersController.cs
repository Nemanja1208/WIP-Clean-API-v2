using Application.Commands.Users.Register;
using Application.Queries.Users.Login;
using Application.Dtos.Users;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Application.Validators.User;
using Application.Dtos.Errors;
using Application.Exceptions.Authorize;
using Domain.Shared.Validations;
using Domain.Models.User;

namespace API.Controllers.UsersController
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        internal readonly IMediator _mediator;
        internal readonly UserValidator _userValidator;

        public UsersController(IMediator mediator, UserValidator userValidator)
        {
            _mediator = mediator;
            _userValidator = userValidator;
        }

        [HttpPost("register")]
        [ProducesResponseType(typeof(UserCredentialsDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Errors), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Register([FromBody] UserCredentialsDto userToRegister)
        {
            //var inputValidation = _userValidator.Validate(userToRegister);

            //if (!inputValidation.IsValid)
            //{
            //    return BadRequest(inputValidation.Errors.ConvertAll(errors => errors.ErrorMessage));
            //}

            Result<UserModel> result = await _mediator.Send(new RegisterUserCommand(userToRegister));

            if (result.IsFailure)
            {
                return HandleFailure(result);
            }

            return Ok(result.Value);

            //try
            //{
            //    Result<UserCredentialsDto> result = await _mediator.Send(new RegisterUserCommand(userToRegister));
            //    //return Ok(await _mediator.Send(new RegisterUserCommand(userToRegister)));
            //}
            //catch (ArgumentException e)
            //{
            //    //// Log the error and return an error response
            //    //_logger.LogError(e, "Error registering user");
            //    return BadRequest(e.Message);
            //}
        }

        private IActionResult HandleFailure(Result<UserModel> result) =>
            result switch
            {
                { IsSuccess: true } => throw new InvalidOperationException(),
                IValidationResult validationResult =>
                    BadRequest(CreateProblemDetails("Validation Error", StatusCodes.Status400BadRequest, result.Errors[0], validationResult.Errors)),
                _ => BadRequest(CreateProblemDetails("Bad Request", StatusCodes.Status400BadRequest, result.Errors[0], result.Errors))
            };

        private static ProblemDetails CreateProblemDetails(string title, int status, Error error, Error[] errors) => new()
        {
            Title = title,
            Type = error.Code,
            Detail = error.Message,
            Status = status,
            Extensions = { { nameof(errors), errors } },
        };

        [HttpPost("login")]
        [ProducesResponseType(typeof(TokenDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Errors), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Login([FromBody] UserCredentialsDto userToLogin)
        {
            var inputValidation = _userValidator.Validate(userToLogin);

            if (!inputValidation.IsValid)
            {
                return BadRequest(inputValidation.Errors.ConvertAll(errors => errors.ErrorMessage));
            }

            try
            {
                string token = await _mediator.Send(new LoginUserQuery(userToLogin));

                return Ok(new TokenDto { TokenValue = token });
            }
            catch (UnAuthorizedException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
