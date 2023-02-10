using FluentValidation;

namespace NZWalks_API.Validators
{
    public class AddRegionValidator : AbstractValidator<Models.DTO.RegionCreateDTO>
    {
        public AddRegionValidator()
        {
            RuleFor(x => x.Code).NotEmpty();
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Area).GreaterThan(0);
            RuleFor(x => x.Population).GreaterThanOrEqualTo(0);
        }
    }
}
