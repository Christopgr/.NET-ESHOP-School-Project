using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ncs2019_team_TBD.Models
{
	public class Material
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public IEnumerable<ProductMaterial> ProductMaterials { get; internal set; }
	}
}
