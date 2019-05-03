using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ncs2019_team_TBD.Models
{
		public class User : IdentityUser
		{
            public string FirstName { get; set; }

			public string LastName { get; set; }

            public string Address { get; set; }

			public int AddressNumber { get; set; }

			public string City { get; set; }

			public int ZipCode { get; set; }

			public double TotalPurchase { get; set; }

			public Boolean ActiveOrder { get; set; }
	
			public virtual Cart Cart { get; set; }
			/// <summary>
			/// a user can have many orders
			/// </summary>
			public ICollection<Order> Orders { get; set; }
		}
}
