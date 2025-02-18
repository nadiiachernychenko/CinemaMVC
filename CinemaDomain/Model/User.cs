using System;
using System.Collections.Generic;

namespace CinemaDomain.Model;

public partial class User:Entity
{

    public string UsName { get; set; } = null!;

    public string UsEmail { get; set; } = null!;

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();
}
