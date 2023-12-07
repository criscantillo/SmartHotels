using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SmartHotels.Data.Models;
using SmartHotels.DTOs;

namespace SmartHotels.Data.SeedWork
{
    public class SearchRoomRepository : ISearchRoomRepository
    {
        private readonly DbSet<Room> _dbSet;

        public SearchRoomRepository(SmartHotelContext context)
        {
            _dbSet = context.Set<Room>();
        }

        public async Task<IEnumerable<Room>> GetRoomsFromFilter(FilterRoomDto filterRoom)
        {
            List<SqlParameter> queryParams = new List<SqlParameter> 
            {
                new SqlParameter("@from", filterRoom.FromDate),
                new SqlParameter("@to", filterRoom.ToDate),
                new SqlParameter("@num_guests", filterRoom.Guests),
                new SqlParameter("@city", filterRoom.City)
            };

            List<Room> lstSearchRoom = 
                await _dbSet.FromSqlRaw(GetQuery(), queryParams.ToArray()).ToListAsync();

            return lstSearchRoom;
        }

        private string GetQuery()
        {
            string SQL = @" SELECT r.* 
                            FROM room r
	                            INNER JOIN hotel h ON r.hotel_id = h.hotel_id
	                            LEFT JOIN reservation rs ON r.room_id = rs.room_id
                            WHERE h.active = 1
                            AND r.active = 1
                            AND h.city = @city
                            AND r.capacity >= @num_guests
                            AND (
	                            rs.from_date IS NULL 
	                            OR (rs.from_date NOT BETWEEN @from AND @to AND rs.to_date NOT BETWEEN @from AND @to)
                            )";
            return SQL;
        }
    }
}
