using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.Repositories
{
    public class DogRepository(AppDbContext context) : IDogRepository
    {
        public async Task<Dog> AddDog(Dog dog)
        {
            await context.Dogs.AddAsync(dog);
            await context.SaveChangesAsync();
            return dog;
        }

        public async Task<bool> DeleteDog(Guid id)
        {
            var dog = await GetDogById(id);
            if (dog == null) return false;
            context.Dogs.Remove(dog);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Dog>> GetAllDogs()
        {
            return await context.Dogs.Include(d => d.Owner).ToListAsync();
            //return await context.Dogs.Include(d => d.Owner).ToListAsync();
        }


        public async Task<Dog?> GetDogById(Guid id)
        {
            return await context.Dogs
                .Include(d => d.Owner)
                .Include(d => d.Trips)
                .ThenInclude(t => t.Walker)
                   .FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task<Dog> UpdateDog(Dog dog)
        {
            context.Dogs.Update(dog);
            await context.SaveChangesAsync();
            return dog;
        }
    }
}