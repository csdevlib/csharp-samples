﻿using System.Collections.Generic;

namespace Graphapi.Data
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public List<Components> Components { get; set; }

        public ProductType ProductType { get; set; }
    }

    public enum ProductType
    {
        CPU, 
        MONITOR,
        EXTERNALS
    }
}
