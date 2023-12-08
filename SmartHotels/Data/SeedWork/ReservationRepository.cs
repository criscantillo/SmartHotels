using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SmartHotels.Data.Models;

namespace SmartHotels.Data.SeedWork
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly DbSet<Reservation> _dbSet;

        public ReservationRepository(SmartHotelContext context)
        {
            _dbSet = context.Set<Reservation>();
        }
        public async Task<IEnumerable<Reservation>> GetReservationFromAdmin(string userId)
        {
            List<SqlParameter> queryParams = new List<SqlParameter>
            {
                new SqlParameter("@userId", userId)
            };

            List<Reservation> lstReservation =
                await _dbSet.FromSqlRaw(GetQuery(), queryParams.ToArray()).ToListAsync();

            return lstReservation;
        }

        private string GetQuery()
        {
            string SQL = @" SELECT rs.*
                            FROM reservation rs
	                            INNER JOIN hotel h ON rs.hotel_id = h.hotel_id
	                            INNER JOIN user_app u ON h.user_id = u.user_id AND u.user_type = 1
                            WHERE u.user_id = @userId";
            return SQL;
        }
    }
}
