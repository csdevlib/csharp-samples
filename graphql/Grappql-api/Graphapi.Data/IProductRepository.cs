using System.Collections.Generic;

namespace Graphapi.Data
{
    public interface IProductRepository
    {
        Product AddProduct(Product product);
        List<Product> GetAllProducts();

        Product GetProductById(int id);
        Product GetProductByName(string name);
    }
}