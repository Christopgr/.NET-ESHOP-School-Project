using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ncs2019_team_TBD.Models
{
	public class CartItem
	{
		public int CartId { get; set; }

		public int ProductId { get; set; }

		public int Quantity { get; set; }
	}
}
