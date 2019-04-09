using System.Collections.Generic;

namespace WebApplication2.Models

{
    public class Materials : ModelBase
    {
        public IEnumerable<ProductMaterials> ProductMaterials { get; set; }
    }
}