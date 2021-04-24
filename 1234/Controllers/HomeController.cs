using System.Linq;
using Microsoft.AspNetCore.Mvc;
using _1234.Models;
using _1234.Models.Repository.ProductRepository;
using System.Dynamic;
using Microsoft.AspNetCore.Authorization;

namespace _1234.Controllers
{
    public class HomeController : Controller
    {
        private IProductRepository ProductRepository;

        public HomeController(IProductRepository productRepository)
        {
            ProductRepository = productRepository;
        }

        [Authorize(Roles = "admin")]
        public ActionResult Index()
        {
            dynamic mymodel = new ExpandoObject();
            mymodel.Products = ProductRepository.Get();
            return View(mymodel);
        }

        [Authorize(Roles = "admin")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public ActionResult Create(Product product)
        {
            ProductRepository.Create(product);
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "admin")]
        public ActionResult Details(int? id)
        {
            if (id != null)
            {
                    return View(ProductRepository.Get(id));
            }
            return NotFound();
        }

        [Authorize(Roles = "admin")]
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
        [Authorize(Roles = "admin")]
        public IActionResult Edit(Product product)
        {
            ProductRepository.Update(product);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [ActionName("Delete")]
        [Authorize(Roles = "admin")]
        public IActionResult ConfirmDelete(int? id)
        {
            if (id != null)
            {
                    return View(ProductRepository.Get(id));
            }
            return NotFound();
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
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
}
