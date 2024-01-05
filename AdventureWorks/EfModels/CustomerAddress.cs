using System;
using System.Collections.Generic;

namespace AdventureWorks.EfModels;

public partial class CustomerAddress
{
    public int CustomerId { get; set; }

    public int AddressId { get; set; }

    public string AddressType { get; set; } = null!;

    public string Rowguid { get; set; } = null!;

    public string ModifiedDate { get; set; } = null!;
}
