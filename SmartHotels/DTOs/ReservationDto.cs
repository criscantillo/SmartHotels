namespace SmartHotels.DTOs
{
    public class ReservationDto
    {
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public int HotelId { get; set; }
        public int RoomId { get; set; }
        public string UserId { get; set; } = string.Empty;
        public string EmergencyContactName { get; set; } = string.Empty;
        public string EmergencyContactPhone { get; set; } = string.Empty;
        public IEnumerable<string> GuestIds { get; set; } = new List<string>();
    }
}
