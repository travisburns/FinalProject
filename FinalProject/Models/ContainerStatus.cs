using System;
using System.Collections.Generic;

namespace FinalProject.Models
{
    public partial class ContainerStatus
    {
        public ContainerStatus()
        {
            BrewContainers = new HashSet<BrewContainer>();
        }

        public int ContainerStatusId { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<BrewContainer> BrewContainers { get; set; }
    }
}
