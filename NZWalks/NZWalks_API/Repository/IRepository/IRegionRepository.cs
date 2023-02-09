using NZWalks_API.Models.Domain;

namespace NZWalks_API.Repository.IRepository
{
    public interface IRegionRepository
    {
        Task<IEnumerable<Region>> GetAllRegion();
    }
}
