using Microsoft.EntityFrameworkCore;
using NZWalks_API.Data;
using NZWalks_API.Models.Domain;
using NZWalks_API.Repository.IRepository;

namespace NZWalks_API.Repository
{
    public class RegionRepository : IRegionRepository
    {
        private readonly NZWalksDbContext _db;

        public RegionRepository(NZWalksDbContext db)
        {
            this._db = db;
        }
        public async Task<IEnumerable<Region>> GetAllRegion()
        {
            return await _db.Regions.ToListAsync();
        }


    }
}
