using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Features.Trips.DTOs
{
    public class TripDto
    {
        public Guid Id { get; set; }
        public string Date { get; set; } = string.Empty; // Als Text formatiert für React
        public string WalkerName { get; set; } = string.Empty;
        public int DurationMinutes { get; set; }
        public int Rating { get; set; }
    }
}