using System;
using System.Collections.Generic;
using _1234.Models.Cart;

namespace _1234.Models.Repository.OrderLineRepository
{
    public class OrderLineRepository : IOrderLineRepository
    {

        ApplicationContext Context;

        public OrderLineRepository(ApplicationContext context)
        {
            Context = context;
        }

        public void Create(OrderLine orderLine)
        {
            Context.OrderLines.Add(orderLine);
            Context.SaveChanges();
        }

        public IEnumerable<OrderLine> Get()
        {
            return Context.OrderLines;
        }

        public OrderLine Get(int? id)
        {
            return Context.OrderLines.Find(id);
        }
    }
}
