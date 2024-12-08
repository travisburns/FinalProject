using System;
using System.Collections.Generic;

namespace FinalProject.Models
{
    public partial class UseDuring
    {
        public UseDuring()
        {
            Adjuncts = new HashSet<Adjunct>();
            RecipeIngredients = new HashSet<RecipeIngredient>();
        }

        public int UseDuringId { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Adjunct> Adjuncts { get; set; }
        public virtual ICollection<RecipeIngredient> RecipeIngredients { get; set; }
    }
}
