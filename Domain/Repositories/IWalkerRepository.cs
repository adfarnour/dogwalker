
using Domain.Entities;

namespace Domain.Repositories
{
    public interface IWalkerRepository
    {
        Task<Walker> GetWalkerById(Guid walkerId);
        Task<List<Walker>> GetAllWalkers();
        Task<Walker> AddWalker(Walker walker);
        Task<Walker> UpdateWalker(Walker walker);
        Task<bool> DeleteWalker(Guid walkerId);
    }
}