using SmartHotels.Data.Models;

namespace SmartHotels.Data.SeedWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SmartHotelContext _context;
        private readonly IRepository<Hotel> _hotelRepository;
        private readonly IRepository<Room> _roomRepository;
        private readonly IRepository<Guest> _guestRepository;
        private readonly IRepository<Reservation> _reservationRepository;
        public IRepository<Hotel> Hotels {
            get
            {
                return _hotelRepository;
            }
        }

        public IRepository<Room> Rooms
        {
            get
            {
                return _roomRepository;
            }
        }

        public IRepository<Guest> Guests
        {
            get
            {
                return _guestRepository;
            }
        }

        public IRepository<Reservation> Reservations
        {
            get
            {
                return _reservationRepository;
            }
        }

        public UnitOfWork(SmartHotelContext context)
        {
            _context = context;
            _hotelRepository = new Repository<Hotel>(_context);
            _roomRepository = new Repository<Room>(_context);
            _guestRepository = new Repository<Guest>(_context);
            _reservationRepository = new Repository<Reservation>(_context);
        }

        public async Task<int> Save()
        {
            int result = await _context.SaveChangesAsync();
            return result;
        }
    }
}
