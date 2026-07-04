
using Application.Features.Dogs.Commands;
using Application.Features.Dogs.Queries;

using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    public class DogController(IMediator mediator) : ControllerBase
    {

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dog>>> GetDogs()
        {
            var result = await mediator.Send(new GetDogsListQuery());
            return Ok(result);
        }

        [HttpGet("{id}")] 
        public async Task<ActionResult<Dog>> GetDogById(Guid id)
        {
            var result = await mediator.Send(new GetDogByIdQuery(id));
            if(result == null) return NotFound($"Dog with id {id} not found");
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateDog(
            [FromBody] CreateDogCommand command)
        {
            var result = await mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("{id}")] 
        public async Task<ActionResult<Guid>> UpdateDog(
            Guid id, [FromBody] UpdateDogCommand input)
        {
            var command = new UpdateDogCommand(
                id, input.Name, input.Breed, input.OwnerId);

            if(id != command.Id) return BadRequest(
                $"the id in the url {id} is different from the id in the body {command.Id}");
            
            var result = await mediator.Send(command);

            if(!result) return NotFound($"Dog with id {id} not found");

            return NoContent();
        }

        [HttpDelete("{id}")] 
        public async Task<ActionResult<bool>> DeleteDog(Guid id)
        {
            var result = await mediator.Send(new DeleteDogCommand(id));
            if(!result) return NotFound($"Dog with id {id} not found");
            return NoContent();
        }
    }
}