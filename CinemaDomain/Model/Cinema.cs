using System;
using System.Collections.Generic;

namespace CinemaDomain.Model;

public partial class Cinema:Entity
{

    public string CnName { get; set; } = null!;

    public string CnAddress { get; set; } = null!;

    public virtual City CnNameNavigation { get; set; } = null!;

    public virtual ICollection<Session> Sessions { get; set; } = new List<Session>();
}
