using Application.Features.Dogs.DTOs;
using Domain.Repositories;
using MediatR;

namespace Application.Features.Dogs.Queries
{
    public record GetDogsListQuery() : IRequest<IEnumerable<DogDto>>;

public class GetDogsListQueryHandler(IDogRepository dogRepository)
    : IRequestHandler<GetDogsListQuery, IEnumerable<DogDto>>
{
    public async Task<IEnumerable<DogDto>> Handle(
        GetDogsListQuery request, CancellationToken cancellationToken)
    {
        var dogs = await dogRepository.GetAllDogs();
        
        var dogDtos = dogs.Select(dog => new DogDto
        {
            Id = dog.Id,
            Name = dog.Name,
            Breed = dog.Breed,
            OwnerName = dog.Owner != null ? dog.Owner.Name : "Unknown",
            PhotoUrl = dog.PhotoUrl,
            Gender = dog.Gender
        });

        return dogDtos;
    }
}
}