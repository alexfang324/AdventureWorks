using AdventureWorks.Controllers;
using AdventureWorks.EfModels;
using AdventureWorks.Interfaces;
using AdventureWorks.ViewModels;
using Microsoft.CodeAnalysis;

namespace AdventureWorks.Respositories
{
    public class ProductCategoryRepository : IRepository<ProductCategoryVM>
    {
        private readonly AdventureWorksContext _db;

        public ProductCategoryRepository(ILogger<HomeController> logger
                                , AdventureWorksContext db)
        {
            _db = db;
        }

        public ProductCategoryVM Get(int id)
        {
            ProductCategoryVM productCategory = GetAll().FirstOrDefault(p => p.ProductId == id);

            return productCategory;
        }

        public List<ProductCategoryVM> GetAll()
        {
            List<ProductCategoryVM> productCategories = _db.ProductCategories.Join(_db.Products
                                                                                    , (pc) => pc.ProductCategoryId
                                                                                    , (p) => p.ProductCategoryId
                                                                                    , (pc, p) => new ProductCategoryVM
                                                                                    {
                                                                                        ProductId = p.ProductId,
                                                                                        ProductName = p.Name,
                                                                                        ProductNumber = p.ProductNumber,
                                                                                        ProductColor = p.Color,
                                                                                        CategoryName = pc.Name
                                                                                    }).ToList();

            return productCategories;
        }
    }
}

