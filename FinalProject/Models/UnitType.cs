using System;
using System.Collections.Generic;

namespace FinalProject.Models
{
    public partial class UnitType
    {
        public UnitType()
        {
            Ingredients = new HashSet<Ingredient>();
        }

        public int UnitTypeId { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Ingredient> Ingredients { get; set; }
    }
}
