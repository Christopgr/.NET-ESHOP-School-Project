using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ncs2019_team_TBD.Models
{
    public class Order {
		
		public int Id { set; get; }

		public int CustomerId { set; get; }

		public int Quantity { set; get; }

		public DateTime DateCreated { set; get; }

		public string State { set; get; }
	}
}
