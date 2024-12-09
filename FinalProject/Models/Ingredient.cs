using System;
using System.Collections.Generic;

namespace FinalProject.Models;

public partial class Ingredient
{
    public int IngredientId { get; set; }

    public string Name { get; set; } = null!;

    public int? Version { get; set; }

    public int IngredientTypeId { get; set; }

    public double OnHandQuantity { get; set; }

    public int UnitTypeId { get; set; }

    public decimal UnitCost { get; set; }

    public double ReorderPoint { get; set; }

    public string? Notes { get; set; }

    public virtual Adjunct? Adjunct { get; set; }

    public virtual Fermentable? Fermentable { get; set; }

    public virtual Hop? Hop { get; set; }

    public virtual ICollection<IngredientInventoryAddition> IngredientInventoryAdditions { get; set; } = new List<IngredientInventoryAddition>();

    public virtual ICollection<IngredientInventorySubtraction> IngredientInventorySubtractions { get; set; } = new List<IngredientInventorySubtraction>();

    public virtual IngredientType IngredientType { get; set; } = null!;

    public virtual ICollection<RecipeIngredient> RecipeIngredients { get; set; } = new List<RecipeIngredient>();

    public virtual UnitType UnitType { get; set; } = null!;

    public virtual Yeast? Yeast { get; set; }

    public virtual ICollection<Ingredient> Ingredients { get; set; } = new List<Ingredient>();

    public virtual ICollection<Style> Styles { get; set; } = new List<Style>();

    public virtual ICollection<Ingredient> SubstituteIngredients { get; set; } = new List<Ingredient>();
}
