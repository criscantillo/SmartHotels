namespace SmartHotels.DTOs
{
    public class Reservation
    {
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public int MaxGuests { get; set; }
        public DateTime ReservateAt { get; set; }
        public string UserId { get; set; } = string.Empty;
        public double TotalPrice { get; set; }
        public EmergencyConcact EmergencyConcact { get; set; } = new EmergencyConcact();
        public IList<GuestDto> Guests { get; set; } = new List<GuestDto>();
    }

    public class EmergencyConcact 
    {
        public string Name { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
    }
}
