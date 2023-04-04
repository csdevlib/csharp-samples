using Graphapi.Data;
using System.Collections.Generic;

namespace Graphapi.TestProject
{
    public class ProductQueryResponse
    {
        public IEnumerable<Product> Products { get; set; }
    }
}