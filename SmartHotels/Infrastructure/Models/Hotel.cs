namespace SmartHotels.Infrastructure.Models;

public partial class Hotel
{
    public int HotelId { get; set; }

    public string? Name { get; set; }

    public string? Address { get; set; }

    public int? Stars { get; set; }

    public bool? Active { get; set; }

    public virtual ICollection<Room> Rooms { get; set; } = new List<Room>();
}
