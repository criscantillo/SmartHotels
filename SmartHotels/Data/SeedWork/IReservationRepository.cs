using SmartHotels.Data.Models;

namespace SmartHotels.Data.SeedWork
{
    public interface IReservationRepository
    {
        Task<IEnumerable<Reservation>> GetReservationFromAdmin(string userId);
    }
}
