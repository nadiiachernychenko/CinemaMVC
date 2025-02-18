using System;
using System.Collections.Generic;

namespace CinemaDomain.Model;

public partial class Session:Entity
{

    public string SssMovieId { get; set; } = null!;

    public string SssCinemaId { get; set; } = null!;

    public string SssTime { get; set; } = null!;

    public string SssPrice { get; set; } = null!;

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    public virtual Cinema SssCinema { get; set; } = null!;

    public virtual Movie SssMovie { get; set; } = null!;
}
