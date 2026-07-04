using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Repositories
{
    public interface IOwnerReporsitory
    {
        Task<Owner> GetOwnerById(Guid id);
        Task<List<Owner>> GetAllOwners();
        Task<Owner> CreateOwner(Owner owner);
        Task<Owner> UpdateOwner(Guid id, Owner owner);
        Task<bool> DeleteOwner(Guid id);
    }
}