using SmartHotels.Data.Models;

namespace SmartHotels.Data.SeedWork
{
    public interface IUnitOfWork
    {
        public IRepository<Hotel> Hotels { get; }
        public IRepository<Room> Rooms { get; }
        public IRepository<Guest> Guests { get; }
        public IRepository<Reservation> Reservations { get; }
        public IRepository<UserApp> Users { get; }

        public Task<int> Save();
    }
}
