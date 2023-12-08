using FluentValidation;
using SmartHotels.DTOs;

namespace SmartHotels.Application.Validators
{
    public class HotelValidator : AbstractValidator<HotelDto>
    {
        public HotelValidator() 
        {
            RuleFor(x => x.Name).NotEmpty().MinimumLength(3).MaximumLength(50);
            RuleFor(x => x.City).NotEmpty().MinimumLength(3).MaximumLength(80);
            RuleFor(x => x.Address).NotEmpty().MinimumLength(10).MaximumLength(200);
            RuleFor(x => x.Stars).InclusiveBetween(1, 5);
            RuleFor(x => x.UserId).NotEmpty();
        }
    }
}
