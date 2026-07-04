using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Repositories
{
    public interface ITripRepository
    {
        // Geändert: Gibt nun einen einzelnen, optionalen Trip zurück
        Task<Trip?> GetTripById(Guid tripId);

        Task<IEnumerable<Trip>> GetAllTrips();
        Task<IEnumerable<Trip>> GetTripsByDogId(Guid dogId);
        Task<IEnumerable<Trip>> GetTripsByWalkerId(Guid walkerId);
        Task<Trip> AddTrip(Trip trip);
        Task<Trip> UpdateTrip(Trip trip); 
        Task<bool> DeleteTrip(Guid tripId);
    }

}   