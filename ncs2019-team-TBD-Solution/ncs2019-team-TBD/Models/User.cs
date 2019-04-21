﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ncs2019_team_TBD.Models
{
		public class User : BaseModel
		{
			public string Surname { get; set; }

			public string Email { get; set; }

			public string Password { get; set; }

			public int Phone { get; set; }

			public string Adress { get; set; }

			public int AdressNumber { get; set; }

			public string City { get; set; }

			public int ZipCode { get; set; }

			public double TotalPurchase { get; set; }

			public Boolean ActiveOrder { get; set; }

			/// <summary>
			/// a user can have many orders
			/// </summary>
			public ICollection<Order> Orders { get; set; }
		}
}
