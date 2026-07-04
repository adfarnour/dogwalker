using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Trip
    {
        public Guid Id { get; set; }
        public int DurationInMinutes { get; set; }
        public DateTime TripDate { get; set; }
        public int Rating { get; set; } // 1 - 5 Sterne nach Abschluss
        public Guid DogId { get; set; }
        public Dog? Dog { get; set; }

        public Guid WalkerId { get; set; } 
        public Walker Walker { get; set; } = null!;

    }
}