using System;
using System.Collections.Generic;

namespace AdventureWorks.EfModels;

public partial class SalesOrderDetail
{
    public int SalesOrderId { get; set; }

    public int SalesOrderDetailId { get; set; }

    public long OrderQty { get; set; }

    public int ProductId { get; set; }

    public double UnitPrice { get; set; }

    public double UnitPriceDiscount { get; set; }

    public string Rowguid { get; set; } = null!;

    public string ModifiedDate { get; set; } = null!;
}
