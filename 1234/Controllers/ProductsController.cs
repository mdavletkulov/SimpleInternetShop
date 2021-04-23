using System;
using _1234.Models.Repository.ProductRepository;
using Microsoft.AspNetCore.Mvc;

namespace _1234.Controllers
{
    public class ProductsController : Controller
    {

        private IProductRepository ProductRepository;

        public ProductsController(IProductRepository productRepository)
        {
            ProductRepository = productRepository;
        }


        public ActionResult Index()
        {
            return View(ProductRepository.Get());
        }
    }
}
