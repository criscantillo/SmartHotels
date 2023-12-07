namespace SmartHotels.DTOs
{
    public class FilterRoomDto
    {
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public int Guests { get; set; }
        public string City { get; set; } = string.Empty;
    }
}
