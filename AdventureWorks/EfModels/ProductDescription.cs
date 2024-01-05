using System;
using System.Collections.Generic;

namespace AdventureWorks.EfModels;

public partial class ProductDescription
{
    public int ProductDescriptionId { get; set; }

    public string Description { get; set; } = null!;

    public string Rowguid { get; set; } = null!;

    public string ModifiedDate { get; set; } = null!;
}
