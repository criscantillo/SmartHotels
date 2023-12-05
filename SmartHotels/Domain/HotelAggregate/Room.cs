namespace SmartHotels.Domain.HotelAggregate
{
    public class Room
    {
        public string Location { get; set; } = string.Empty;
        public int Type { get; set; } 
        public string City { get; set; } = string.Empty;
        public int Capacity { get; set; }
        public double BasePrice { get; set; }
        public double Taxes { get; set; }
    }
}
