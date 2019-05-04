using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ncs2019_team_TBD.Models
{
	public class ProductMaterial
	{
		/// <summary>
		/// every ProductMaterial can have only 1 Material and 1 Product
		/// to percentage m arese kai to evala. Deixnei poso pososto apo to kathe uliko periexei to Product
		/// </summary>
		public int ProductId { get; set; }

		public int MaterialId { get; set; }
		public Material Material { get; set; }
		public Product Product { get; set; }
	}
}
