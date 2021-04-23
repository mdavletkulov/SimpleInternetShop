using System;
using System.Collections.Generic;

namespace _1234.Models.Repository.ProductRepository
{
    public class ProductRepository : IProductRepository
    {

        private ApplicationContext Context;

        public ProductRepository(ApplicationContext context)
        {
            Context = context;
        }

        public void Create(Product product)
        {
            Context.Products.Add(product);
            Context.SaveChanges();
        }

        public Product Delete(int? id)
        {
            Product product = Get(id);

            if (product != null)
            {
                Context.Products.Remove(product);
                Context.SaveChanges();
            }

            return product;
        }

        public IEnumerable<Product> Get()
        {
            return Context.Products;
        }

        public Product Get(int? id)
        {
            return Context.Products.Find(id);
        }

        public void Update(Product product)
        {
            Product currentItem = Get(product.Id);
            currentItem.Name = product.Name;
            currentItem.Count = product.Count;
            currentItem.Price = product.Price;
            currentItem.Description = product.Description;

            Context.Products.Update(currentItem);
            Context.SaveChanges();
        }      
    }
}
