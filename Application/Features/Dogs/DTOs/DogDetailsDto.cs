using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Trips.DTOs;

namespace Application.Features.Dogs.DTOs
{
    public class DogDetailsDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Breed { get; set; } = string.Empty;
        public Guid OwnerId { get; set; }
        public string OwnerName { get; set; } = string.Empty;
        public string OwnerEmail { get; set; } = string.Empty;
        public string OwnerAddress { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
        public string PhotoUrl { get; set; } = string.Empty;
        public List<TripDto> UpcomingTrips { get; set; } = new();
    }
}