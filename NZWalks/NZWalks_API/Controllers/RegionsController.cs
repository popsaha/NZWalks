using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NZWalks_API.Models.Domain;
using NZWalks_API.Repository.IRepository;

namespace NZWalks_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegionsController : Controller
    {
        private readonly IRegionRepository _regionRepository;
        private readonly IMapper _mapper;

        public RegionsController(IRegionRepository regionRepository, IMapper mapper)
        {
            this._regionRepository = regionRepository;
            this._mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRegions()
        {
            var regions = await _regionRepository.GetAllRegion();

            var regionsDTO = _mapper.Map<List<Models.DTO.Region>>(regions);
            return Ok(regionsDTO);
        }

        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetRegionById")]
        public async Task<IActionResult> GetRegionById(Guid id)
        {
            var region = await _regionRepository.GetRegion(id);
            if (region == null)
            {
                return NotFound();
            }
            var regionDTO = _mapper.Map<Models.DTO.Region>(region);
            return Ok(regionDTO);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddRegion([FromBody] Models.DTO.RegionCreateDTO createDTO)
        {
            //validate the request


            // request(DTO) to Domain Model
            //var regionDomain = _mapper.Map<Models.Domain.Region>(createDTO);
            var regionDomain = new Region()
            {
                Code = createDTO.Code,
                Name = createDTO.Name,
                Area = createDTO.Area,
                Lat = createDTO.Lat,
                Long = createDTO.Long,
                Population = createDTO.Population
            };

            // Pass details to repository
            regionDomain = await _regionRepository.AddRegion(regionDomain);

            // Convert back to DTO
            var regionDTO = _mapper.Map<Models.Domain.Region>(regionDomain);

            return CreatedAtAction(nameof(GetRegionById), new { id = regionDTO.Id }, regionDTO);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        [Authorize]
        public async Task<IActionResult> DeleteRegion(Guid id)
        {
            //get region from database
            var regionDomain = await _regionRepository.DeleteRegion(id);

            //If null then Not Found
            if (regionDomain == null)
            {
                return NotFound();
            }

            //Convert response back to DTO
            var regionDTO = _mapper.Map<Models.DTO.Region>(regionDomain);

            //return Ok response to client.
            return Ok(regionDTO);
        }

        [HttpPut]
        [Route("{id:guid}")]
        [Authorize]
        public async Task<IActionResult> UpdateRegion([FromRoute] Guid id, [FromBody] Models.DTO.RegionUpdateDTO regionUpdateDTO)
        {
            //Convert DTO to domain model
            //var regionDomain = _mapper.Map<Models.Domain.Region>(regionUpdateDTO);
            var regionDomain = new Models.Domain.Region()
            {
                Code = regionUpdateDTO.Code,
                Name = regionUpdateDTO.Name,
                Area = regionUpdateDTO.Area,
                Lat = regionUpdateDTO.Lat,
                Long = regionUpdateDTO.Long,
                Population = regionUpdateDTO.Population
            };


            //update region using repositoy
            regionDomain = await _regionRepository.UpdateRegion(id, regionDomain);

            //if null not found
            if (regionDomain == null)
            {
                return NotFound();
            }

            //convert domain back to DTO
            //var regionDTO = _mapper.Map<Models.DTO.RegionUpdateDTO>(regionDomain);
            var regionDTO = new Models.DTO.RegionUpdateDTO()
            {
                Code = regionDomain.Code,
                Name = regionDomain.Name,
                Area = regionDomain.Area,
                Lat = regionDomain.Lat,
                Long = regionDomain.Long,
                Population = regionDomain.Population
            };

            //return Ok response
            return Ok(regionDTO);
        }

        #region Private Methods
        private void ValidateAddRegion(Models.DTO.RegionCreateDTO createDTO)
        {
            if (string.IsNullOrWhiteSpace(createDTO.Code))
            {
                ModelState.AddModelError(nameof(createDTO.Code), $"{nameof(createDTO.Code)} cannot be null");
            }
        }
        #endregion
    }
}
