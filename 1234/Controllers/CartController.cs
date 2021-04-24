using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using _1234.Models;
using _1234.Models.Cart;
using _1234.Models.Repository.OrderRepository;
using _1234.Models.Repository.OrderLineRepository;
using _1234.Models.Repository.ProductRepository;
using _1234.Utils;
using Microsoft.AspNetCore.Mvc;

namespace _1234.Controllers
{
    public class CartController : Controller
    {
        private IProductRepository ProductRepository;
        private IOrderRepository OrderRepository;

        public CartController(IProductRepository productRepository,
            IOrderRepository orderRepository)
        {
            ProductRepository = productRepository;
            OrderRepository = orderRepository;
        }

        public ActionResult Index()
        {
            return View(GetCart());
        }

        public Cart GetCart() {
            Cart cart = HttpContext.Session.GetComplexData<Cart>("Cart");
            if (cart == null)
            {
                cart = new Cart();
                HttpContext.Session.SetComplexData("Cart", cart);
            }
            return cart;
        }

        [HttpPost]
        public ActionResult AddToCart(int productId, int quantity)
        {
            Product product = ProductRepository.Get(productId);

            if (product != null) {
                int productCount = ProductRepository.Get(productId).Count;

                if (quantity is 0) {
                    TempData["countError"] = "Кол-во не может быть нулевым!";
                    return RedirectToAction("Index", "Products");
                }

                if (quantity > productCount ||
                    quantity + GetCartProductCount(productId) > productCount) {
                    TempData["countError"] = "Товара не хватает на складе!";
                    return RedirectToAction("Index", "Products");
                }
                    

                Cart cart = GetCart();
                cart.AddLine(new ProductEntity(product), quantity);
                HttpContext.Session.SetComplexData("Cart", cart);
            }

            return RedirectToAction("Index");
        }

        public ActionResult RemoveFromCart(int productId)
        {
            Product product = ProductRepository.Get(productId);

            if (product != null)
            {
                Cart cart = GetCart();
                cart.RemoveLine(productId);
                HttpContext.Session.SetComplexData("Cart", cart);
            }

            return RedirectToAction("Index");
        }

        public ActionResult RemoveAll()
        {
                Cart cart = GetCart();
                cart.Clear();
                HttpContext.Session.SetComplexData("Cart", cart);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult ConfirmOrder(string FirstName, string SecondName, string ThirdName,
            string Phone, string Email)
        {
            if (String.IsNullOrEmpty(FirstName) || String.IsNullOrEmpty(SecondName) ||
                String.IsNullOrEmpty(ThirdName) || String.IsNullOrEmpty(Phone)
                || String.IsNullOrEmpty(Email)) {
                TempData["CartError"] = "Не все поля заполнены!";
                return RedirectToAction("Index");
            }

            Cart cart = GetCart();

            if (cart.Lines.Count() <= 0)
            {
                TempData["CartError"] = "Корзина пуста!";
                return RedirectToAction("Index");
            }

            List<OrderLine> orderLines = new List<OrderLine>();
            Order order = new Order();

            foreach (CartLine line in cart.Lines)
            {
                Product product = ProductRepository.Get(line.Product.Id);
                OrderLine orderLine = new OrderLine();
                orderLine.Count = line.Quantity;
                orderLine.Product = product;
                orderLine.Order = order;
                orderLines.Add(orderLine);
                product.Count -= line.Quantity;
                ProductRepository.Update(product);
            }

            order.OrderLines = orderLines;
            order.FirstName = FirstName;
            order.SecondName = SecondName;
            order.ThirdName = ThirdName;
            order.Phone = Phone;
            order.Email = Email;

            OrderRepository.Create(order);

            TempData["successOrderCreation"] = "Заказ создан!";
            return RemoveAll();
        }

        public int GetCartProductCount(int productId) {
            Cart cart = GetCart();

            CartLine cartLine = cart.Lines
                .Where(l => l.Product.Id == productId)
                .FirstOrDefault();

            if (cartLine != null) {
                return cartLine.Quantity;
            }
            return 0;
        }

    }
}
