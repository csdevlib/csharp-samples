using System.Collections.Generic;
using System.Linq;

namespace Graphapi.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductDbContext productDbContext;

        public ProductRepository(ProductDbContext productDbContext)
        {
            this.productDbContext = productDbContext;
        }

        public List<Product> GetAllProducts()
        {
            return productDbContext.Products.ToList();
        }

        public Product GetProductByName(string name)
        {
            return productDbContext.Products.Where(p => p.Name == name).FirstOrDefault();
        }

        public Product GetProductById(int id)
        {
            return productDbContext.Products.Where(p => p.Id == id).FirstOrDefault();
        }

        public Product AddProduct(Product product)
        {
            productDbContext.Products.Add(product);
            productDbContext.SaveChanges();

            return product;
        }
    }
}
