using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ncs2019_team_TBD.Models
{
	public class OrderItem
	{
		public int OrderId { get; set; }

		public int ProductId { get; set; }

		public int Quantity { get; set; }
	}
}
