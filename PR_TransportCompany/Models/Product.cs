using System;
using System.Collections.Generic;

namespace PR_TransportCompany.Models;

public partial class Product
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Manufacturer { get; set; } = null!;
}
