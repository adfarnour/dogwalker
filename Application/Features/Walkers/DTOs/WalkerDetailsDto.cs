using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Dogs.DTOs;

namespace Application.Features.Walkers.DTOs
{
    public class WalkerDetailsDto
    {
        public int Id { get; set; }
        public string WalkerName { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public double PricePerHour { get; set; } 
        public string ImageUrl { get; set; } = string.Empty;
        public List<DogDto> Dogs { get; set; } = new();
    }
}