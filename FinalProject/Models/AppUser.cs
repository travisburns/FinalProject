using System;
using System.Collections.Generic;

namespace FinalProject.Models;

public partial class AppUser
{
    public int AppUserId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<InventoryTransaction> InventoryTransactions { get; set; } = new List<InventoryTransaction>();
}
