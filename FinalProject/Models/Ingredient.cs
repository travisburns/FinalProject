using System;
using System.Collections.Generic;

namespace FinalProject.Models
{
    public partial class Ingredient
    {
        public Ingredient()
        {
            IngredientInventoryAdditions = new HashSet<IngredientInventoryAddition>();
            IngredientInventorySubtractions = new HashSet<IngredientInventorySubtraction>();
            RecipeIngredients = new HashSet<RecipeIngredient>();
            Ingredients = new HashSet<Ingredient>();
            Styles = new HashSet<Style>();
            SubstituteIngredients = new HashSet<Ingredient>();
        }

        public int IngredientId { get; set; }
        public string Name { get; set; } = null!;
        public int? Version { get; set; }
        public int IngredientTypeId { get; set; }
        public double OnHandQuantity { get; set; }
        public int UnitTypeId { get; set; }
        public decimal UnitCost { get; set; }
        public double ReorderPoint { get; set; }
        public string? Notes { get; set; }

        public virtual IngredientType IngredientType { get; set; } = null!;
        public virtual UnitType UnitType { get; set; } = null!;
        public virtual Adjunct? Adjunct { get; set; }
        public virtual Fermentable? Fermentable { get; set; }
        public virtual Hop? Hop { get; set; }
        public virtual Yeast? Yeast { get; set; }
        public virtual ICollection<IngredientInventoryAddition> IngredientInventoryAdditions { get; set; }
        public virtual ICollection<IngredientInventorySubtraction> IngredientInventorySubtractions { get; set; }
        public virtual ICollection<RecipeIngredient> RecipeIngredients { get; set; }

        public virtual ICollection<Ingredient> Ingredients { get; set; }
        public virtual ICollection<Style> Styles { get; set; }
        public virtual ICollection<Ingredient> SubstituteIngredients { get; set; }
    }
}
