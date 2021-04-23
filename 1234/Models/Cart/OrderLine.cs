using System;
namespace _1234.Models.Cart
{
    public class OrderLine
    {
        public int Id { get; set; }
        public int Count { get; set; }

        public virtual Order Order { get; set; }

        public virtual Product Product { get; set; }
    }
}
