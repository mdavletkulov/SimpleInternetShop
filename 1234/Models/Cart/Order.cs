using System;
using System.Collections.Generic;

namespace _1234.Models.Cart
{
    public class Order
    {
        public int Id { get; set; }
        public virtual List<OrderLine> OrderLines { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
