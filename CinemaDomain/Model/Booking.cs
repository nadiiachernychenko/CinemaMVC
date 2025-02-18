using System;
using System.Collections.Generic;

namespace CinemaDomain.Model;

public partial class Booking:Entity
{

    public string BkSeats { get; set; } = null!;

    public string BkDate { get; set; } = null!;

    public string BkUserId { get; set; } = null!;

    public string BkSessionId { get; set; } = null!;

    public virtual Session BkSession { get; set; } = null!;

    public virtual User BkUser { get; set; } = null!;
}
