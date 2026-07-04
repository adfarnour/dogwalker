
using Domain.Repositories;
using Domain.Entities;
using MediatR;

namespace Application.Features.Dogs.Commands
{
    public record CreateDogCommand(string Name, string Breed, Guid OwnerId) 
                : IRequest<Guid>;
    public class CreateDogCommandHandler(IDogRepository dogRepository)
      : IRequestHandler<CreateDogCommand, Guid>
    {
        public async Task<Guid> Handle(
            CreateDogCommand request, CancellationToken cancellationToken)
        {
            var dog = new Dog
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Breed = request.Breed,
                OwnerId = request.OwnerId
            };

            var saveDog = await dogRepository.AddDog(dog);

            return saveDog.Id;
        }
    }
}
