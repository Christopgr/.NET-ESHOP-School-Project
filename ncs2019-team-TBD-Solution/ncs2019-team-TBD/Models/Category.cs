using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ncs2019_team_TBD.Models
{
	public class Category : BaseModel
	{
		/// <summary>
		/// declares that a category can have many products
		/// a category can have many products
		/// </summary>
		public IEnumerable<Product> Products { get; set; }
	}
}
