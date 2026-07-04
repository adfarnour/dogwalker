using Application.Features.Dogs.DTOs;
using Application.Features.Trips.DTOs;
using Domain.Repositories;
using MediatR;

namespace Application.Features.Dogs.Queries
{
    public record GetDogByIdQuery(Guid Id) : IRequest<DogDetailsDto>;

    public class GetDogByIdQueryHandler(IDogRepository dogRepository)
    : IRequestHandler<GetDogByIdQuery, DogDetailsDto?>
    {
        public async Task<DogDetailsDto?> Handle(GetDogByIdQuery request, CancellationToken cancellationToken)
        {
            // WICHTIG: Das Repository muss ".Include(d => d.Trips)" nutzen!
            var dog = await dogRepository.GetDogById(request.Id);
            if (dog == null) return null;

            return new DogDetailsDto
            {
                Id = dog.Id,
                Name = dog.Name,
                PhotoUrl = dog.PhotoUrl,
                // ... Besitzerdaten ...
                OwnerId = dog.OwnerId,
                OwnerName = dog.Owner != null ? dog.Owner.Name : "Kein Besitzer eingetragen",
                OwnerEmail = dog.Owner != null ? dog.Owner.Email : "",
                OwnerAddress = dog.Owner != null ? dog.Owner.Address : "",
                
                // C#-Kombination: Aus List<Trip> wird List<TripDto> gemacht
                UpcomingTrips = dog.Trips.Select(trip => new TripDto
                {
                    Id = trip.Id,
                    Date = trip.TripDate.ToString("dd.MM.yyyy"), // Schickes Format für das Frontend
                    WalkerName = trip.Walker.Name ?? "Henry Habib",
                    DurationMinutes = trip.DurationInMinutes,
                    Rating = trip.Rating
                }).ToList() // Zurück in eine Liste konvertieren
            };
        }
    }



}