using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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


		[DataType(DataType.Currency)]
		public float Price { get; set; }

        public string Img { get; set; }

		/// <summary>
		/// only 1 Category
		/// </summary>
		public virtual Category Category { get; set; }

		/// <summary>
		/// but many ProductMaterials and OrderProducts
		/// </summary>
		public ICollection<ProductMaterial> ProductMaterials { get; set; }

		public ICollection<OrderItem> OrderItems { get; set; }

		public ICollection<CartItem> CartItems { get; set; }
	}
}
