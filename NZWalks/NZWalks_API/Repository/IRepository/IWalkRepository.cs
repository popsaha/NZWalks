using NZWalks_API.Models.Domain;

namespace NZWalks_API.Repository.IRepository
{
    public interface IWalkRepository
    {
        Task<IEnumerable<Walk>> GetAllWalk();
        Task<Walk> GetWalk(Guid id);

        Task<Walk> AddWalk(Walk walk);
        Task<Walk> UpdateWalk(Guid id, Walk walk);
        Task<Walk> DeleteWalk(Guid id);
    }
}
