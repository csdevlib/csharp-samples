using System.Collections.Generic;
using System.Linq;

namespace Graphapi.Data
{
    public class ComponentRepository : IComponentRepository
    {
        private readonly ProductDbContext productDbContext;

        public ComponentRepository(ProductDbContext productDbContext)
        {
            this.productDbContext = productDbContext;
        }


        public Components AddComponent(Components component)
        {
            productDbContext.Components.Add(component);
            productDbContext.SaveChanges();

            return component;
        }

        public List<Components> GetComponentsByProductId(int id)
        {
            return productDbContext.Components.Where(p => p.ProductId == id).ToList();
        }

        public Components GetComponentById(int id)
        {
            return productDbContext.Components.Where(p => p.Id == id).FirstOrDefault();
        }

        public Components GetComponentByName(string name, int productId)
        {
            return productDbContext.Components.Where(p => p.Name == name && p.ProductId == productId).FirstOrDefault();
        }
    }
}
