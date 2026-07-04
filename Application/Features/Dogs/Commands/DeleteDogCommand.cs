using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Repositories;
using MediatR;

namespace Application.Features.Dogs.Commands
{
    public record DeleteDogCommand(Guid Id) : IRequest<bool>;
    public class DeleteDogCommandHandler(IDogRepository dogRepository)
      : IRequestHandler<DeleteDogCommand, bool>
    {
        public async Task<bool> Handle(DeleteDogCommand request, CancellationToken cancellationToken)
        {
            return await dogRepository.DeleteDog(request.Id);
        }
    }
}