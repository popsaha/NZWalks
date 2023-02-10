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



        public async Task<Region> AddRegion(Region region)
        {
            region.Id = Guid.NewGuid();
            await _db.Regions.AddAsync(region);
            await _db.SaveChangesAsync();
            return region;
        }

        public async Task<Region> DeleteRegion(Guid id)
        {

            var region = await _db.Regions.FirstOrDefaultAsync(u => u.Id == id);
            if (region == null) { return null; }

            //delete region
            _db.Regions.Remove(region);
            await _db.SaveChangesAsync();
            return region;

        }

        public async Task<IEnumerable<Region>> GetAllRegion()
        {
            return await _db.Regions.ToListAsync();
        }

        public async Task<Region> GetRegion(Guid id)
        {

            return await _db.Regions.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Region> UpdateRegion(Guid id, Region region)
        {
            var existingRegion = await _db.Regions.FirstOrDefaultAsync(x => x.Id == id);

            if (existingRegion == null)
            {
                return null;
            }

            existingRegion.Code = region.Code;
            existingRegion.Name = region.Name;
            existingRegion.Area = region.Area;
            existingRegion.Lat = region.Lat;
            existingRegion.Long = region.Long;
            existingRegion.Population = region.Population;

            await _db.SaveChangesAsync();

            return existingRegion;
        }
    }
}
