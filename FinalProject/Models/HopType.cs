using System;
using System.Collections.Generic;

namespace FinalProject.Models;

public partial class HopType
{
    public int HopTypeId { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Hop> Hops { get; set; } = new List<Hop>();
}
