using System;
using System.Collections.Generic;

namespace SmartHotels.Infrastructure.Models;

public partial class Room
{
    public int RoomId { get; set; }

    public int HotelId { get; set; }

    public string? Location { get; set; }

    public short? Type { get; set; }


    public short? Capacity { get; set; }

    public double? BasePrice { get; set; }

    public double? Taxes { get; set; }

    public virtual Hotel Hotel { get; set; } = null!;
}
