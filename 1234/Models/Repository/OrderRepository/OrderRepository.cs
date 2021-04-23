using System;
using System.Collections.Generic;
using System.Linq;
using _1234.Models.Cart;
using Microsoft.EntityFrameworkCore;

namespace _1234.Models.Repository.OrderRepository
{
    public class OrderRepository : IOrderRepository
    {

        private ApplicationContext Context;

        public OrderRepository(ApplicationContext contex)
        {
            Context = contex;
        }

        public void Create(Order order)
        {
            Context.Orders.Add(order);
            Context.SaveChanges();
        }

        public IEnumerable<Order> Get()
        {
            return Context.Orders.Include(o => o.OrderLines)
                .ThenInclude(o => o.Product);
        }

        public Order Get(int? id)
        {
            return Context.Orders.Include(o => o.OrderLines)
                .ThenInclude(o => o.Product)
                .SingleOrDefault(o => o.Id == id);
        }
    }
}
