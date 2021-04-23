using System.Linq;
using Microsoft.AspNetCore.Mvc;
using _1234.Models;
using _1234.Models.Repository.ProductRepository;
using System.Dynamic;

namespace _1234.Controllers
{
    public class HomeController : Controller
    {
        private IProductRepository ProductRepository;

        public HomeController(IProductRepository productRepository)
        {
            ProductRepository = productRepository;
        }

        public ActionResult Index()
        {
            dynamic mymodel = new ExpandoObject();
            mymodel.Products = ProductRepository.Get();
            return View(mymodel);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product product)
        {
            ProductRepository.Create(product);
            return RedirectToAction("Index");
        }

        public ActionResult Details(int? id)
        {
            if (id != null)
            {
                    return View(ProductRepository.Get(id));
            }
            return NotFound();
        }

        public IActionResult Edit(int? id)
        {
            if (id != null)
            {
                Product product = ProductRepository.Get(id);
                if (product != null)
                    return View(product);
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            ProductRepository.Update(product);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [ActionName("Delete")]
        public IActionResult ConfirmDelete(int? id)
        {
            if (id != null)
            {
                    return View(ProductRepository.Get(id));
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult Delete(int? id)
        {
            if (id != null)
            {
                ProductRepository.Delete(id);
                return RedirectToAction("Index");
            }
            return NotFound();
        }

    }



    //private readonly ILogger<HomeController> _logger;

    //public HomeController(ILogger<HomeController> logger)
    //{
    //    _logger = logger;
    //}

    //public IActionResult Index()
    //{
    //    return View();
    //}

    //public IActionResult Privacy()
    //{
    //    return View();
    //}

    //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    //public IActionResult Error()
    //{
    //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    //}
}
