using System.Collections.Generic;

namespace Graphapi.Data
{
    public interface IComponentRepository
    {
        Components AddComponent(Components component);

        List<Components> GetComponentsByProductId(int id);

        Components GetComponentById(int id);

        Components GetComponentByName(string name, int productId);
    }
}