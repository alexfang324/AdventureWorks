using System;
using System.Collections.Generic;

namespace AdventureWorks.EfModels;

public partial class ProductCategory
{
    public int ProductCategoryId { get; set; }

    public int? ParentProductCategoryId { get; set; }

    public string Name { get; set; } = null!;

    public string Rowguid { get; set; } = null!;

    public string ModifiedDate { get; set; } = null!;
}
