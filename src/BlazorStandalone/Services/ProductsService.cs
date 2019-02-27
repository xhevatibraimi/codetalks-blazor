using BlazorStandalone.Models;
using System.Collections.Generic;
using System.Linq;

namespace BlazorStandalone.Services
{
    public class ProductsService
    {
        private readonly List<Product> Products = new List<Product>();

        public ProductsService()
        {
            this.Products = new List<Product>
            {
                new Product{Id = System.Guid.NewGuid().ToString(), Name= "banana", Desc="green banana"},
                new Product{Id = System.Guid.NewGuid().ToString(), Name= "orange", Desc="orange orange"},
                new Product{Id = System.Guid.NewGuid().ToString(), Name= "pineapple", Desc="the whole world calls it ananas"},
            };
        }

        public Product GetPorduct(string id)
        {
            return Products.FirstOrDefault(x => x.Id == id);
        }

        public List<Product> GetAllProducts() => Products;

        public void CreateProduct(Product p)
        {
            p.Id = System.Guid.NewGuid().ToString();
            Products.Add(p);
        }

        public void EditProduct(Product p)
        {
            var product = Products.FirstOrDefault(x => x.Id == p?.Id);
            if (product != null)
            {
                product.Name = p.Name;
                product.Desc = p.Desc;
            }
        }

        public void DeleteProduct(string id)
        {
            var product = Products.FirstOrDefault(x => x.Id == id);
            if (product != null)
            {
                Products.Remove(product);
            }
        }
    }
}
