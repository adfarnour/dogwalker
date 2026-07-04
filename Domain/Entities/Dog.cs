using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Dog
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Breed { get; set; } = string.Empty; // Rasse
        public int Age { get; set; }
        public string Gender { get; set; } = string.Empty;
        public Guid OwnerId { get; set; }
        public Owner? Owner { get; set; }
        public string PhotoUrl { get; set; } = string.Empty;
        public List<Trip> Trips { get; set; } = new List<Trip>();
    }
}