using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Dogs.DTOs;
using Application.Features.Trips.DTOs;

namespace Application.Features.Owners.DTOs
{
    public class OwnerDetailsDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        
        public List<DogDto> Dogs { get; set; } = new();
        public List<TripDto> Trips { get; set; } = new();
    }
}