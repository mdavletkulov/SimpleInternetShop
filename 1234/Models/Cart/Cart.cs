using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _1234.Models.Cart
{
    public class Cart
    {

        private List<CartLine> lineCollection = new List<CartLine>();

        public IEnumerable<CartLine> Lines { get { return lineCollection; } }

        public void AddLine(ProductEntity product, int quantity) {
            CartLine line = lineCollection
                .Where(p => p.Product.Id == product.Id)
                .FirstOrDefault();

            if (line == null)
            {
                lineCollection.Add(new CartLine(product, quantity));
            }
            else {
                line.Quantity += quantity;
            }
        }

        public void RemoveLine(int id) {
            lineCollection.RemoveAll(p => p.Product.Id == id);
        }

        public int ComputePrice()
        {
            return lineCollection.Sum(p => p.Product.Price * p.Quantity);
        }

        public void Clear()
        {
            lineCollection.Clear();
        }

    }

    public class CartLine {

        public CartLine(ProductEntity product, int quantity) {
            Product = product;
            Quantity = quantity;
        }

        public ProductEntity Product { get; set; }
        public int Quantity { get; set; }
    }
       
}
