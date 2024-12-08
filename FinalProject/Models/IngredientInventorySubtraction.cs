using System;
using System.Collections.Generic;

namespace FinalProject.Models
{
    public partial class IngredientInventorySubtraction
    {
        public int IngredientInventorySubtractionId { get; set; }
        public int IngredientId { get; set; }
        public DateTime TransactionDate { get; set; }
        public string Reason { get; set; } = null!;
        public int? BatchId { get; set; }
        public double Quantity { get; set; }

        public virtual Batch? Batch { get; set; }
        public virtual Ingredient Ingredient { get; set; } = null!;
    }
}
