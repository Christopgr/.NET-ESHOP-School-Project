using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ncs2019_team_TBD.Models
{
    public class Product
    {
        public int Id { get; set; }

        public int CategoryId { get; set; }

        public string Description { get; set; }

        public int InventoryQuantity { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateUpdated { get; set; }
    
        public int SerialNumber { get; set; }

        public int Price { get; set; }

		public virtual Category Category { get; set; }

		public IEnumerable<ProductMaterial> ProductMaterials { get; internal set; }

		public IEnumerable<OrderProduct> OrderProducts { get; internal set; }
	}
}
