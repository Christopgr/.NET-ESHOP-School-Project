using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ncs2019_team_TBD.Models
{
    public class Order : BaseModel
	{

		public int UserId { get; set; }

		public int Quantity { get; set; }

		public string State { get; set; }

		/// <summary>
		/// declares that an order can have only 1 user
		/// alla den xerw giati xreiazetai afou dhlwnoume UserID
		/// </summary>
		public virtual User User { get; set; }

		/// <summary>
		/// declares that an order can have many orderproduct 
		/// an order can be in many OrderProducts
		/// </summary>
		public ICollection<OrderProduct> OrderProducts { get; set; }
	}
}
