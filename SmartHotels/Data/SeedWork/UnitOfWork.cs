﻿using SmartHotels.Infrastructure.Models;

namespace SmartHotels.Data.SeedWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SmartHotelContext _context;
        private readonly IRepository<Hotel> _hotelRepository;
        private readonly IRepository<Room> _roomRepository;
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

        public UnitOfWork(SmartHotelContext context)
        {
            _context = context;
            _hotelRepository = new Repository<Hotel>(_context);
            _roomRepository = new Repository<Room>(_context);
        }

        public async Task<int> Save()
        {
            int result = await _context.SaveChangesAsync();
            return result;
        }
    }
}
