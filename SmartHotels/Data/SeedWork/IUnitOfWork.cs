using SmartHotels.Infrastructure.Models;

namespace SmartHotels.Data.SeedWork
{
    public interface IUnitOfWork
    {
        public IRepository<Hotel> Hotels { get; }
        public IRepository<Room> Rooms { get; }

        public Task<int> Save();
    }
}
