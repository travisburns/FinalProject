using System;
using System.Collections.Generic;

namespace FinalProject.Models
{
    public partial class ContainerType
    {
        public ContainerType()
        {
            BrewContainers = new HashSet<BrewContainer>();
        }

        public int ContainerTypeId { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<BrewContainer> BrewContainers { get; set; }
    }
}
