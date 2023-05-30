using System;
using System.Collections.Generic;

namespace PR_TransportCompany.Models;

public partial class Route
{
    public int Id { get; set; }

    public string PointOfDeparture { get; set; } = null!;

    public string PointOfStay { get; set; } = null!;

    public string Product { get; set; } = null!;

    public string Transport { get; set; } = null!;
}
