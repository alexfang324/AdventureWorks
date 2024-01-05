using System;
using System.Collections.Generic;

namespace AdventureWorks.EfModels;

public partial class ProductModelProductDescription
{
    public int ProductModelId { get; set; }

    public int ProductDescriptionId { get; set; }

    public string Culture { get; set; } = null!;

    public string Rowguid { get; set; } = null!;

    public string ModifiedDate { get; set; } = null!;
}
