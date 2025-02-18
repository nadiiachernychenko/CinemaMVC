using System;
using System.Collections.Generic;

namespace CinemaDomain.Model;

public partial class Movie:Entity
{

    public string MvName { get; set; } = null!;

    public string MvDuration { get; set; } = null!;

    public string MvDescription { get; set; } = null!;

    public string MvReleaseYear { get; set; } = null!;

    public virtual ICollection<Session> Sessions { get; set; } = new List<Session>();
}
