﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ncs2019_team_TBD.Models
{
    public class Order {
		
		public int Id { get; set; }

		public int UserId { get; set; }

		public int Quantity { get; set; }

		public DateTime DateCreated { get; set; }

		public string State { get; set; }

		public virtual User User { get; set; }

		public IEnumerable<OrderProduct> OrderProducts { get; internal set; }
	}
}
