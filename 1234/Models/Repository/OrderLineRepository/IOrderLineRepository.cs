using System;
using System.Collections.Generic;
using _1234.Models.Cart;

namespace _1234.Models.Repository.OrderLineRepository
{
    public interface IOrderLineRepository
    {
        IEnumerable<OrderLine> Get();
        OrderLine Get(int? id);
        void Create(OrderLine orderLine);
    }
}
