using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ncs2019_team_TBD.Models
{
    public class Order : BaseModel
	{

		public string UserId { get; set; }

		public string State { get; set; }

		/// <summary>
		/// declares that an order can have only 1 user
		/// </summary>
		public virtual User User { get; set; }

		/// <summary>
		/// declares that an order can have many orderproduct 
		/// an order can be in many OrderProducts
		/// </summary>
		public ICollection<OrderItem> OrderItems { get; set; }
	}
}
