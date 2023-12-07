using SmartHotels.Data.Models;
using SmartHotels.DTOs;

namespace SmartHotels.Data.SeedWork
{
    public interface ISearchRoomRepository
    {
        Task<IEnumerable<Room>> GetRoomsFromFilter(FilterRoomDto filterRoom);
    }
}
