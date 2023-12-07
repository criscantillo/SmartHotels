using System;
using System.Collections.Generic;

namespace SmartHotels.Data.Models;

public partial class Reservation
{
    public int ReserveId { get; set; }

    public int HotelId { get; set; }

    public int RoomId { get; set; }

    public DateTime FromDate { get; set; }

    public DateTime ToDate { get; set; }

    public DateTime ReserveAt { get; set; }

    public string? EmergencyContactName { get; set; }

    public string? EmergencyContactPhone { get; set; }

    public string UserId { get; set; } = null!;

    public string GuestIds { get; set; } = null!;

    public double TotalPrice { get; set; }
}
