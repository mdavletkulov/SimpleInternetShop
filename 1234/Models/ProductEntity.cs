using System;
namespace _1234.Models
{
    public class ProductEntity
    {

        public ProductEntity()
        {
        }

        public ProductEntity(Product product) {
            Id = product.Id;
            Name = product.Name;
            Description = product.Description;
            Price = product.Price;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
    }
}
