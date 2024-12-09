using System;
using System.Collections.Generic;

namespace FinalProject.Models;

public partial class ContainerType
{
    public int ContainerTypeId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<BrewContainer> BrewContainers { get; set; } = new List<BrewContainer>();
}
