using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorks.EfModels;

public partial class AdventureWorksContext : DbContext
{
    public AdventureWorksContext()
    {
    }

    public AdventureWorksContext(DbContextOptions<AdventureWorksContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<BuildVersion> BuildVersions { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<CustomerAddress> CustomerAddresses { get; set; }

    public virtual DbSet<ErrorLog> ErrorLogs { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductCategory> ProductCategories { get; set; }

    public virtual DbSet<ProductDescription> ProductDescriptions { get; set; }

    public virtual DbSet<ProductModel> ProductModels { get; set; }

    public virtual DbSet<ProductModelProductDescription> ProductModelProductDescriptions { get; set; }

    public virtual DbSet<SalesOrderDetail> SalesOrderDetails { get; set; }

    public virtual DbSet<SalesOrderHeader> SalesOrderHeaders { get; set; }

    public virtual DbSet<VGetAllCategory> VGetAllCategories { get; set; }

    public virtual DbSet<VProductAndDescription> VProductAndDescriptions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Address>(entity =>
        {
            entity.ToTable("Address");

            entity.Property(e => e.AddressId).HasColumnName("AddressID");
            entity.Property(e => e.Rowguid).HasColumnName("rowguid");
        });

        modelBuilder.Entity<BuildVersion>(entity =>
        {
            entity.HasKey(e => e.SystemInformationId);

            entity.ToTable("BuildVersion");

            entity.Property(e => e.SystemInformationId).HasColumnName("SystemInformationID");
            entity.Property(e => e.DatabaseVersion).HasColumnName("Database_Version");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.ToTable("Customer");

            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.Rowguid).HasColumnName("rowguid");
        });

        modelBuilder.Entity<CustomerAddress>(entity =>
        {
            entity.HasKey(e => new { e.CustomerId, e.AddressId });

            entity.ToTable("CustomerAddress");

            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.AddressId).HasColumnName("AddressID");
            entity.Property(e => e.Rowguid).HasColumnName("rowguid");
        });

        modelBuilder.Entity<ErrorLog>(entity =>
        {
            entity.ToTable("ErrorLog");

            entity.Property(e => e.ErrorLogId).HasColumnName("ErrorLogID");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.ToTable("Product");

            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.ProductCategoryId).HasColumnName("ProductCategoryID");
            entity.Property(e => e.ProductModelId).HasColumnName("ProductModelID");
            entity.Property(e => e.Rowguid).HasColumnName("rowguid");
        });

        modelBuilder.Entity<ProductCategory>(entity =>
        {
            entity.ToTable("ProductCategory");

            entity.Property(e => e.ProductCategoryId).HasColumnName("ProductCategoryID");
            entity.Property(e => e.ParentProductCategoryId).HasColumnName("ParentProductCategoryID");
            entity.Property(e => e.Rowguid).HasColumnName("rowguid");
        });

        modelBuilder.Entity<ProductDescription>(entity =>
        {
            entity.ToTable("ProductDescription");

            entity.Property(e => e.ProductDescriptionId).HasColumnName("ProductDescriptionID");
            entity.Property(e => e.Rowguid).HasColumnName("rowguid");
        });

        modelBuilder.Entity<ProductModel>(entity =>
        {
            entity.ToTable("ProductModel");

            entity.Property(e => e.ProductModelId).HasColumnName("ProductModelID");
            entity.Property(e => e.Rowguid).HasColumnName("rowguid");
        });

        modelBuilder.Entity<ProductModelProductDescription>(entity =>
        {
            entity.HasKey(e => new { e.ProductModelId, e.ProductDescriptionId, e.Culture });

            entity.ToTable("ProductModelProductDescription");

            entity.Property(e => e.ProductModelId).HasColumnName("ProductModelID");
            entity.Property(e => e.ProductDescriptionId).HasColumnName("ProductDescriptionID");
            entity.Property(e => e.Rowguid).HasColumnName("rowguid");
        });

        modelBuilder.Entity<SalesOrderDetail>(entity =>
        {
            entity.ToTable("SalesOrderDetail");

            entity.Property(e => e.SalesOrderDetailId).HasColumnName("SalesOrderDetailID");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.Rowguid).HasColumnName("rowguid");
            entity.Property(e => e.SalesOrderId).HasColumnName("SalesOrderID");
        });

        modelBuilder.Entity<SalesOrderHeader>(entity =>
        {
            entity.HasKey(e => e.SalesOrderId);

            entity.ToTable("SalesOrderHeader");

            entity.Property(e => e.SalesOrderId).HasColumnName("SalesOrderID");
            entity.Property(e => e.BillToAddressId).HasColumnName("BillToAddressID");
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.Rowguid).HasColumnName("rowguid");
            entity.Property(e => e.ShipToAddressId).HasColumnName("ShipToAddressID");
        });

        modelBuilder.Entity<VGetAllCategory>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vGetAllCategories");

            entity.Property(e => e.ProductCategoryId).HasColumnName("ProductCategoryID");
        });

        modelBuilder.Entity<VProductAndDescription>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vProductAndDescription");

            entity.Property(e => e.ProductId).HasColumnName("ProductID");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
