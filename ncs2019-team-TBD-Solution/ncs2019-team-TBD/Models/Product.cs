using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ncs2019_team_TBD.Models
{
    public class Product : BaseModel
    {

        public int CategoryId { get; set; }

        public string Description { get; set; }

        public int InventoryQuantity { get; set; }
    
        public int SerialNumber { get; set; }

        public double Price { get; set; }

		/// <summary>
		/// only 1 Category
		/// </summary>
		public virtual Category Category { get; set; }

		/// <summary>
		/// but many ProductMaterials and OrderProducts
		/// </summary>
		public IEnumerable<ProductMaterial> ProductMaterials { get; internal set; }

		public IEnumerable<OrderProduct> OrderProducts { get; internal set; }
	}
}
