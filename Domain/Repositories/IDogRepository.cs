using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Repositories
{
    public interface IDogRepository
    {
        Task<Dog?> GetDogById(Guid id);
        Task<IEnumerable<Dog>> GetAllDogs();
        Task<Dog> AddDog(Dog dog);
        Task<Dog> UpdateDog(Dog dog);
        Task<bool> DeleteDog(Guid id);
    }
}