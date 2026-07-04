using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Features.Walkers.DTOs
{
    public class WalkerDto
    {
        public int Id { get; set; }
        public string WalkerName { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public double PricePerHour { get; set; }
    }
}