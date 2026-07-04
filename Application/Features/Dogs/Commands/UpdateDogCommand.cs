using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Repositories;
using MediatR;

namespace Application.Features.Dogs.Commands
{
    public record UpdateDogCommand(
        Guid Id, string Name, string Breed, Guid OwnerId) : IRequest<bool>;
    public class UpdateDogCommandHandler(IDogRepository dogRepository)

      : IRequestHandler<UpdateDogCommand, bool>
    {
        public async Task<bool> Handle(
            UpdateDogCommand request, CancellationToken cancellationToken)
        {
            // The existing dog from the database
            var existingDog = await dogRepository.GetDogById(request.Id);

            // if the dog doesn't exist break
            if(existingDog == null) return false;

            // update the dog,. The existing dog data with the new data
            existingDog.Name = request.Name;
            existingDog.Breed = request.Breed;
            existingDog.OwnerId = request.OwnerId;

            // save the dog
            await dogRepository.UpdateDog(existingDog);

            //Success, the api know the dog is updated. Ok
            return true;
        }
    }
}