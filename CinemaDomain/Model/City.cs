using System;
using System.Collections.Generic;

namespace CinemaDomain.Model;

public partial class City:Entity
{

    public string CtName { get; set; } = null!;

    public virtual ICollection<Cinema> Cinemas { get; set; } = new List<Cinema>();
}
