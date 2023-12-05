namespace SmartHotels.Domain.HotelAggregate
{
    public class Hotel
    {
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public int Stars { get; set; }
        public bool Active { get; set; } = true;
    }
}
