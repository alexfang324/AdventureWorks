using System;
using System.Collections.Generic;

namespace AdventureWorks.EfModels;

public partial class Address
{
    public int AddressId { get; set; }

    public string AddressLine1 { get; set; } = null!;

    public string? AddressLine2 { get; set; }

    public string City { get; set; } = null!;

    public string StateProvince { get; set; } = null!;

    public string CountryRegion { get; set; } = null!;

    public string PostalCode { get; set; } = null!;

    public string Rowguid { get; set; } = null!;

    public string ModifiedDate { get; set; } = null!;
}
