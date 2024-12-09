using System;
using System.Collections.Generic;

namespace FinalProject.Models;

public partial class ContainerSize
{
    public int ContainerSizeId { get; set; }

    public string Name { get; set; } = null!;

    public double? MaxVolume { get; set; }

    public double? WorkingVolume { get; set; }

    public virtual ICollection<BrewContainer> BrewContainers { get; set; } = new List<BrewContainer>();
}
