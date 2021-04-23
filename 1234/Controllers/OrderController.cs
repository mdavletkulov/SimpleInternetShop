using System;
using System.Collections.Generic;
using System.Linq;
using _1234.Models.Cart;
using _1234.Models.Repository.OrderRepository;
using Microsoft.AspNetCore.Mvc;

namespace _1234.Controllers
{
    public class OrderController : Controller
    {
        IOrderRepository OrderRepository;

        public OrderController(IOrderRepository orderRepository)
        {
            OrderRepository = orderRepository;
        }

        public ActionResult Index()
        {
            return View(OrderRepository.Get());
        }

    }
}
