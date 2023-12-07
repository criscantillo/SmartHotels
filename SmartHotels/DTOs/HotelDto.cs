namespace SmartHotels.DTOs
{
    public class HotelDto
    {
        public string Name { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public int Stars { get; set; }
        public string UserId { get; set; } = string.Empty;
        public bool Active { get; set; } = true;
    }
}
