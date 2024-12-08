using System;
using System.Collections.Generic;

namespace FinalProject.Models
{
    public partial class Style
    {
        public Style()
        {
            Recipes = new HashSet<Recipe>();
            IngredientsNavigation = new HashSet<Ingredient>();
        }

        public int StyleId { get; set; }
        public string Name { get; set; } = null!;
        public int? Version { get; set; }
        public string? CategoryName { get; set; }
        public string? CategoryNumber { get; set; }
        public string? CategoryLetter { get; set; }
        public string? StyleGuide { get; set; }
        public string? Type { get; set; }
        public double? OgMin { get; set; }
        public double? OgMax { get; set; }
        public double? FgMin { get; set; }
        public double? FgMax { get; set; }
        public double? IbuMin { get; set; }
        public double? IbuMax { get; set; }
        public double? ColorMin { get; set; }
        public double? ColorMax { get; set; }
        public double? CarbMin { get; set; }
        public double? CarbMax { get; set; }
        public double? AbvMin { get; set; }
        public double? AbvMax { get; set; }
        public string? Notes { get; set; }
        public string? Profile { get; set; }
        public string? Ingredients { get; set; }
        public string? Examples { get; set; }

        public virtual ICollection<Recipe> Recipes { get; set; }

        public virtual ICollection<Ingredient> IngredientsNavigation { get; set; }
    }
}
