using System;
using System.Collections.Generic;

namespace FinalProject.Models;

public partial class AppConfig
{
    public int BreweryId { get; set; }

    public string DefaultUnits { get; set; } = null!;

    public string BreweryName { get; set; } = null!;

    public string? HomePageText { get; set; }

    public string? BreweryLogo { get; set; }

    public string? HomePageBackgroundImage { get; set; }

    public string? Color1 { get; set; }

    public string? Color2 { get; set; }

    public string? Color3 { get; set; }

    public string? ColorWhite { get; set; }

    public string? ColorBlack { get; set; }
}
