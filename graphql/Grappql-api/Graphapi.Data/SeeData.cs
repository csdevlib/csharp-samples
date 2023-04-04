using System.Collections.Generic;
using System.Linq;

namespace Graphapi.Data
{
    public static class SeeData
    {
        public static void Seed(this ProductDbContext productDbContext)
        {
            if (!productDbContext.Products.Any())
            {
                var products = new List<Product>
                {
                    new Product()
                    {
                        Id = 1,
                        Name = "Product 1",
                        Description ="Description 1",
                        ProductType = ProductType.CPU,
                        Price = 10,
                        Components =  new List<Components>
                        {
                            new Components{
                                Id = 1,
                                Name = "component 1",
                                Description = "description 1",
                                ProductId = 1,
                            }
                        }
                    }
                };

                productDbContext.Products.AddRange(products);
                productDbContext.SaveChanges();
            }
        }
    }
}
