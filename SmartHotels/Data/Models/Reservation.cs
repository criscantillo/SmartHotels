using System;
using System.Collections.Generic;

namespace SmartHotels.Infrastructure.Models;

public partial class Reservation
{
    public int ReserveId { get; set; }

    public DateTime? FromDate { get; set; }

    public DateTime? ToDate { get; set; }

    public short? MaxGuest { get; set; }

    public DateTime? ReserveAt { get; set; }

    public string? UserId { get; set; }

    public double? TotalPrice { get; set; }
}
