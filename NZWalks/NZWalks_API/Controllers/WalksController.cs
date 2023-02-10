using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NZWalks_API.Repository.IRepository;

namespace NZWalks_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WalksController : Controller
    {
        private readonly IWalkRepository _walkRepository;
        private readonly IMapper _mapper;

        public WalksController(IWalkRepository walkRepository, IMapper mapper)
        {
            this._walkRepository = walkRepository;
            this._mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllWalks()
        {
            var walkDomain = await _walkRepository.GetAllWalk();
            var walkDTO = _mapper.Map<List<Models.DTO.WalkDTO>>(walkDomain);
            return Ok(walkDTO);
        }
    }
}
