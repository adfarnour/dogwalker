using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Walker
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public double PricePerHour { get; set; }
        public string Description { get; set; } = string.Empty;
        public string? ImageUrl { get; set; }

        public List<Trip> Trips { get; set; } = new();
    }
}