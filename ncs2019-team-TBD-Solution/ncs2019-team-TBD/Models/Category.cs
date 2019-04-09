using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ncs2019_team_TBD.Models
{
	public class Category
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public DateTime DateCreated { get; set; }

		public IEnumerable<Product> Products { get; set; }
	}
}
