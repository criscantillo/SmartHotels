using System;
using System.Collections.Generic;

namespace SmartHotels.Data.Models;

public partial class Room
{
    public int RoomId { get; set; }

    public int HotelId { get; set; }

    public string Location { get; set; } = null!;

    public short Type { get; set; }

    public short Capacity { get; set; }

    public double BasePrice { get; set; }

    public double Taxes { get; set; }

    public bool? Active { get; set; }

    public virtual Hotel Hotel { get; set; } = null!;
}
