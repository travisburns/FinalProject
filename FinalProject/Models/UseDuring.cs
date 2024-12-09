using System;
using System.Collections.Generic;

namespace FinalProject.Models;

public partial class UseDuring
{
    public int UseDuringId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Adjunct> Adjuncts { get; set; } = new List<Adjunct>();

    public virtual ICollection<RecipeIngredient> RecipeIngredients { get; set; } = new List<RecipeIngredient>();
}
