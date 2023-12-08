using FluentValidation;
using SmartHotels.DTOs;

namespace SmartHotels.Application.Validators
{
    public class ReservationValidator : AbstractValidator<ReservationDto>
    {
        public ReservationValidator()
        {
            RuleFor(x => x).Must(IsValidRange)
                .WithMessage("La fecha final debe ser mayor a la fecha inicial")
                .WithName("ToDate");
            RuleFor(x => x.UserId).NotEmpty();
            RuleFor(x => x.HotelId).NotEmpty();
            RuleFor(x => x.RoomId).NotEmpty();
            RuleFor(x => x.EmergencyContactPhone).NotEmpty().MinimumLength(3).MaximumLength(20);
            RuleFor(x => x.EmergencyContactName).NotEmpty().MinimumLength(3).MaximumLength(100);
            RuleFor(x => x.GuestIds).Must(x => x == null || x.Any())
                .WithMessage("Debe agregar al menos un Huesped");
            RuleForEach(x => x.GuestIds).NotEmpty();
        }

        private bool IsValidRange(ReservationDto reservation)
        {
            return reservation.ToDate > reservation.FromDate;
        }
    }
}
