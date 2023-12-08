using FluentValidation;
using SmartHotels.DTOs;

namespace SmartHotels.Application.Validators
{
    public class RoomValidator : AbstractValidator<RoomDto>
    {
        public RoomValidator()
        {
            RuleFor(x => x.Location).NotEmpty().MinimumLength(1).MaximumLength(20);
            RuleFor(x => x.Type).InclusiveBetween(1, 5);
            RuleFor(x => x.Capacity).LessThanOrEqualTo(12);
            RuleFor(x => x.BasePrice).GreaterThan(0);
            RuleFor(x => x.Taxes).GreaterThan(0);
        }
    }
}
