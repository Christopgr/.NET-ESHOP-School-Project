using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ncs2019_team_TBD.Models
{
	public class Material : BaseModel
	{
		/// <summary>
		/// declares that a material can have many product materials
		/// a material can be in many ProductMaterials
		/// </summary>
		public ICollection<ProductMaterial> ProductMaterials { get; set; }
	}
}
