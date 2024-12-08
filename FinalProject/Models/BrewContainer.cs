using System;
using System.Collections.Generic;

namespace FinalProject.Models
{
    public partial class BrewContainer
    {
        public BrewContainer()
        {
            BatchContainers = new HashSet<BatchContainer>();
        }

        public int BrewContainerId { get; set; }
        public string Name { get; set; } = null!;
        public int ContainerStatusId { get; set; }
        public int ContainerTypeId { get; set; }
        public int ContainerSizeId { get; set; }

        public virtual ContainerSize ContainerSize { get; set; } = null!;
        public virtual ContainerStatus ContainerStatus { get; set; } = null!;
        public virtual ContainerType ContainerType { get; set; } = null!;
        public virtual Barrel? Barrel { get; set; }
        public virtual ICollection<BatchContainer> BatchContainers { get; set; }
    }
}
