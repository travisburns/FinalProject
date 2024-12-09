using System;
using System.Collections.Generic;

namespace FinalProject.Models;

public partial class Equipment
{
    public int EquipmentId { get; set; }

    public string Name { get; set; } = null!;

    public int? Version { get; set; }

    public double? BoilSize { get; set; }

    public double? BatchSize { get; set; }

    public double? TunVolume { get; set; }

    public double? TunWeight { get; set; }

    public double? TunSpecificHeat { get; set; }

    public double? TopUpWater { get; set; }

    public double? TrubChillerLoss { get; set; }

    public double? EvapRate { get; set; }

    public double? BoilTime { get; set; }

    public sbyte? CalcBoilVolume { get; set; }

    public double? LauterDeadspace { get; set; }

    public double? TopUpKettle { get; set; }

    public double? HopUtilization { get; set; }

    public double? CoolingLossPct { get; set; }

    public string? Notes { get; set; }

    public virtual ICollection<Batch> Batches { get; set; } = new List<Batch>();

    public virtual ICollection<Recipe> Recipes { get; set; } = new List<Recipe>();
}
