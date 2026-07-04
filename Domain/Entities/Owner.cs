using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Owner
    {
       public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        //1:N relationship --> 1 owner can have many dogs
        public List<Dog> Dogs { get; set; } = new();
        public List<Trip> Trips { get; set; } = new();
    }
}