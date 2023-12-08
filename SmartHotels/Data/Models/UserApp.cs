using System;
using System.Collections.Generic;

namespace SmartHotels.Data.Models;

public partial class UserApp
{
    public string UserId { get; set; } = null!;

    public string UserName { get; set; } = null!;

    public string UserEmail { get; set; } = null!;

    public short UserType { get; set; }

    public bool UserActive { get; set; }
}
