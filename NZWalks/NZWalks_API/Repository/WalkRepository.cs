using Microsoft.EntityFrameworkCore;
using NZWalks_API.Data;
using NZWalks_API.Models.Domain;
using NZWalks_API.Repository.IRepository;

namespace NZWalks_API.Repository
{
    public class WalkRepository : IWalkRepository
    {
        private readonly NZWalksDbContext _db;

        public WalkRepository(NZWalksDbContext db)
        {
            this._db = db;
        }

        // Create Walk
        public async Task<Walk> AddWalk(Walk walk)
        {
            throw new NotImplementedException();
        }

        // Delete walk
        public Task<Walk> DeleteWalk(Guid id)
        {
            throw new NotImplementedException();
        }

        // Get all walk
        public async Task<IEnumerable<Walk>> GetAllWalk()
        {
            return await _db.Walks.ToListAsync();
        }

        public Task<Walk> GetWalk(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Walk> UpdateWalk(Guid id, Walk walk)
        {
            throw new NotImplementedException();
        }

        Task<Walk> IWalkRepository.AddWalk(Walk walk)
        {
            throw new NotImplementedException();
        }
    }
}
