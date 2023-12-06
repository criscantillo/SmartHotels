namespace SmartHotels.DTOs
{
    public class RoomDto
    {
        public string Location { get; set; } = string.Empty;
        public int Type { get; set; } 
        public int Capacity { get; set; }
        public double BasePrice { get; set; }
        public double Taxes { get; set; }
    }
}
