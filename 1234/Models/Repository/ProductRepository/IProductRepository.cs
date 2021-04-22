using System;
using System.Collections.Generic;

namespace _1234.Models.Repository.ProductRepository
{
    public interface IProductRepository
    {
        IEnumerable<Product> Get();
        Product Get(int? id);
        void Create(Product product);
        void Update(Product product);
        Product Delete(int? id);
    }
}
