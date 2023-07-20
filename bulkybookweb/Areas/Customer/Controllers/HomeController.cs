using Bulky.Models;
using Bulky.DataAcces.Data;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Bulkybookweb.Controllers
{
    [Area("Customer")]

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDBContext _db;

        public HomeController(ILogger<HomeController> logger, ApplicationDBContext db)
        {
            _logger = logger;
            _db= db;
        }

        public IActionResult Index()
        {
            IEnumerable<Product> products = _db.Products.ToList();
            return View(products);
        }

        public IActionResult Details(int id)
        {
            //    Product res = _db.Products;
            Product product = _db.Products.Find(id);

            Category cat = _db.Categories.Find(product.CategoryId);

           // ViewData["Products"] = res;
            ViewData["category"] = cat.name;
            return View(product);
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