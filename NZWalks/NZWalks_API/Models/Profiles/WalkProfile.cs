using AutoMapper;

namespace NZWalks_API.Models.Profiles
{
    public class WalkProfile : Profile
    {
        public WalkProfile()
        {
            CreateMap<Models.Domain.Walk, Models.DTO.WalkDTO>();
        }
    }
}
