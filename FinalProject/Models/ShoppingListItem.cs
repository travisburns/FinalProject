using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    public class ShoppingListItem
    {
        public Ingredient Ingredient { get; set; }
        public decimal QuantityToOrder { get; set; }
        public decimal CurrentOrders { get; set; }
        public int? SupplierId { get; set; }
        public decimal UnitCost { get; set; }
        public double ScheduledUsage { get; set; }
    }
}
