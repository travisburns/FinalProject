using System;
using System.Collections.Generic;
using System.Linq;
namespace FinalProject.Models
{
    public class ShoppingListGroup
    {
        public int? SupplierId { get; set; }
        public string SupplierName { get; set; }
        public List<ShoppingListItem> Items { get; set; } = new List<ShoppingListItem>();
        public decimal TotalCost => Items.Sum(i => i.QuantityToOrder * i.UnitCost);
        public decimal TotalWeight => Items.Sum(i => i.QuantityToOrder);
    }
}