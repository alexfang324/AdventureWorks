using System;
using System.Collections.Generic;

namespace AdventureWorks.EfModels;

public partial class SalesOrderHeader
{
    public int SalesOrderId { get; set; }

    public long RevisionNumber { get; set; }

    public string OrderDate { get; set; } = null!;

    public string DueDate { get; set; } = null!;

    public string? ShipDate { get; set; }

    public long Status { get; set; }

    public long OnlineOrderFlag { get; set; }

    public string? SalesOrderNumber { get; set; }

    public string? PurchaseOrderNumber { get; set; }

    public string? AccountNumber { get; set; }

    public int CustomerId { get; set; }

    public int? ShipToAddressId { get; set; }

    public int? BillToAddressId { get; set; }

    public string ShipMethod { get; set; } = null!;

    public string? CreditCardApprovalCode { get; set; }

    public double SubTotal { get; set; }

    public double TaxAmt { get; set; }

    public double Freight { get; set; }

    public double? TotalDue { get; set; }

    public string? Comment { get; set; }

    public string Rowguid { get; set; } = null!;

    public string ModifiedDate { get; set; } = null!;
}
