using System;
using System.Collections.Generic;

namespace FinalProject.Models;

public partial class Mash
{
    public int MashId { get; set; }

    public string Name { get; set; } = null!;

    public int? Version { get; set; }

    public double? GrainTemp { get; set; }

    public double? TunTemp { get; set; }

    public double? SpargeTemp { get; set; }

    public double? Ph { get; set; }

    public double? TunWeight { get; set; }

    public double? TunSpecificHeat { get; set; }

    public sbyte? EquipmentAdjust { get; set; }

    public string? Notes { get; set; }

    public virtual ICollection<MashStep> MashSteps { get; set; } = new List<MashStep>();

    public virtual ICollection<Recipe> Recipes { get; set; } = new List<Recipe>();
}
