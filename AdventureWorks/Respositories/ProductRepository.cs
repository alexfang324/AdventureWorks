using AdventureWorks.Controllers;
using AdventureWorks.EfModels;
using AdventureWorks.Interfaces;
using AdventureWorks.ViewModels;

namespace AdventureWorks.Respositories
{
    public class ProductRepository : IRepository<ProductVM>
    {
        private readonly AdventureWorksContext _db;

        public ProductRepository(ILogger<HomeController> logger
                                , AdventureWorksContext db)
        {
            _db = db;
        }

        public ProductVM Get(int id)
        {
            ProductVM product = GetAll().FirstOrDefault(p => p.ProductId == id);

            return product;
        }

        public List<ProductVM> GetAll()
        {
            List<ProductVM> products = _db.Products.Select(p => new ProductVM
            {
                ProductId = p.ProductId,
                Name = p.Name,
                ProductNumber = p.ProductNumber,
                Color = p.Color,
                StandardCost = p.StandardCost,
                ListPrice = p.ListPrice,
            }).ToList();

            return products;
        }
    }

}
