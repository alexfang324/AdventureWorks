using System;
using System.Collections.Generic;

namespace AdventureWorks.EfModels;

public partial class ProductModel
{
    public int ProductModelId { get; set; }

    public string Name { get; set; } = null!;

    public string? CatalogDescription { get; set; }

    public string Rowguid { get; set; } = null!;

    public string ModifiedDate { get; set; } = null!;
}
