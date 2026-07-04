using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Trips.DTOs;

namespace Application.Features.Dogs.DTOs
{
    public class DogDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Breed { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
        public string PhotoUrl { get; set; } = string.Empty;
        public string OwnerName { get; set; } = string.Empty;
         public List<TripDto> UpcomingTrips { get; set; } = new();
        
    }
}