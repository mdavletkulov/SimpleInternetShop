using System;
using System.Collections.Generic;
using _1234.Models.Cart;

namespace _1234.Models.Repository.OrderRepository
{
    public interface IOrderRepository
    {
            IEnumerable<Order> Get();
            Order Get(int? id);
            void Create(Order order);
    }
}
