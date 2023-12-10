using Application.Queries.Dogs.GetAll;
using Application.Queries.UserAnimals;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers.UserAnimalController
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAnimalController : ControllerBase
    {

        internal readonly IMediator _mediator;

        public UserAnimalController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("getAllUserAnimals")]
        public async Task<IActionResult> GetAllUsersWithAnimals()
        {
            return Ok(await _mediator.Send(new GetAllUsersWithAnimalsQuery()));
        }

        //// GET api/<UserAnimalController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<UserAnimalController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<UserAnimalController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<UserAnimalController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
