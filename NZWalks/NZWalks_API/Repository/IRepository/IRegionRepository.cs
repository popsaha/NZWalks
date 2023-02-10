using NZWalks_API.Models.Domain;

namespace NZWalks_API.Repository.IRepository
{
    public interface IRegionRepository
    {
        Task<IEnumerable<Region>> GetAllRegion();
        Task<Region> GetRegion(Guid id);

        Task<Region> AddRegion(Region region);
        Task<Region> UpdateRegion(Guid id, Region region);
        Task<Region> DeleteRegion(Guid id);
    }
}
