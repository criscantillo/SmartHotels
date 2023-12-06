using System;
using System.Collections.Generic;

namespace SmartHotels.Infrastructure.Models;

public partial class Guest
{
    public int GuestId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public DateTime? Birthdate { get; set; }

    public string? Gender { get; set; }

    public string? DocumentType { get; set; }

    public string? DocumentNumber { get; set; }

    public string? Email { get; set; }

    public string? ContactPhone { get; set; }
}
