using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ncs2019_team_TBD.Models
{
	public class OrderProduct
	{
		/// <summary>
		/// every OrderProduct can have only 1 Order and 1 Product
		/// </summary>
		public int OrderId { get; set; }

		public int ProductId { get; set; }
	}
}
