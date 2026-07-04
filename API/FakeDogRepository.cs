using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities; // Passen Sie den Namespace an Ihre Domain an
using Domain.Repositories;

namespace API;

public class FakeDogRepository : IDogRepository
{
    // Eine statische Liste, die wie eine temporäre Datenbank im Arbeitsspeicher fungiert
    private static readonly List<Dog> _dogs = new()
    {
        new Dog { Id = Guid.NewGuid(), Name = "Bello", Breed = "Labrador" },
        new Dog { Id = Guid.NewGuid(), Name = "Luna", Breed = "Golden Retriever" }
    };

    public async Task<IEnumerable<Dog>> GetAllDogs() => await Task.FromResult(_dogs);

    public async Task<Dog?> GetDogById(Guid id) => await Task.FromResult(_dogs.FirstOrDefault(d => d.Id == id)!);

    public async Task<Dog> AddDog(Dog dog)
    {
        _dogs.Add(dog);
        return await Task.FromResult(dog);
    }

    public async Task<Dog> UpdateDog(Dog dog)
    {
        var existing = _dogs.FirstOrDefault(d => d.Id == dog.Id);
        if (existing != null)
        {
            existing.Name = dog.Name;
            existing.Breed = dog.Breed;
        }
        return await Task.FromResult(dog);
    }

    public async Task<bool> DeleteDog(Guid id)
    {
        var dog = _dogs.FirstOrDefault(d => d.Id == id);
        if (dog == null) return await Task.FromResult(false);
        _dogs.Remove(dog);
        return await Task.FromResult(true);
    }
}
