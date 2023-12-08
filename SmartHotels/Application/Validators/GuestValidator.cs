using FluentValidation;
using SmartHotels.DTOs;

namespace SmartHotels.Application.Validators
{
    public class GuestValidator : AbstractValidator<GuestDto>
    {
        public GuestValidator()
        {
            RuleFor(x => x.UserId).NotEmpty();
            RuleFor(x => x.FirstName).NotEmpty().MinimumLength(3).MaximumLength(50);
            RuleFor(x => x.LastName).NotEmpty().MinimumLength(3).MaximumLength(50);
            RuleFor(x => x.Gender).NotEmpty();
            RuleFor(x => x.DocumentType).NotEmpty().MinimumLength(1).MaximumLength(3);
            RuleFor(x => x.DocumentNumber).NotEmpty().MinimumLength(3).MaximumLength(20);
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.ContactPhone).NotEmpty().MinimumLength(3).MaximumLength(15);
        }
    }
}
