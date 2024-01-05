using AdventureWorks.EfModels;
using AdventureWorks.Interfaces;
using AdventureWorks.Models;
using AdventureWorks.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AdventureWorks.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AdventureWorksContext _db;
        private readonly IRepository<ProductVM> _productRepo;

        public HomeController(ILogger<HomeController> logger
                            , AdventureWorksContext db
                            , IRepository<ProductVM> productRepo)
        {
            _logger = logger;
            _db = db;
            _productRepo = productRepo;

        }

        public IActionResult Index(string sortOrder, string searchString, int? pageNumber, int pageSize = 4)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["IDSortParm"] = string.IsNullOrEmpty(sortOrder) ? "idSortDesc" : "";
            ViewData["NameSortParm"] = sortOrder == "Name" ? "nameSortDesc" : "Name";
            ViewData["NumSortParm"] = sortOrder == "Num" ? "numSortDesc" : "Num";

            List<ProductVM> products = _productRepo.GetAll();

            //Filter Search Logic
            if (!string.IsNullOrEmpty(searchString))
            {
                products =
                    products.Where(p => p.Name.Contains(searchString) ||
                                        p.ProductNumber.Contains(searchString)).ToList();
            }

            //List Sorting Logic
            switch (sortOrder)
            {
                case "numSortDesc":
                    products =
                        products.OrderByDescending(p => p.ProductNumber).ToList();
                    break;
                case "Num":
                    products =
                        products.OrderBy(p => p.ProductNumber).ToList();
                    break;
                case "nameSortDesc":
                    products =
                        products.OrderByDescending(p => p.Name).ToList();
                    break;
                case "Name":
                    products =
                        products.OrderBy(p => p.Name).ToList();
                    break;
                case "idSortDesc":
                    products =
                        products.OrderByDescending(p => p.ProductId).ToList();
                    break;
                default:
                    products =
                        products.OrderBy(p => p.ProductId).ToList();
                    break;
            }

            //Pagination Logic
            int pageIndex = pageNumber ?? 1;
            var count = products.Count();
            var items = products.Skip((pageIndex - 1) * pageSize)
                                            .Take(pageSize).ToList();
            var paginatedProducts = new PaginatedList<ProductVM>(items
                                                                , count
                                                                , pageIndex
                                                                , pageSize);
            return View(paginatedProducts);

        }



        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}