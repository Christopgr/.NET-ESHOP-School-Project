using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ncs2019_team_TBD.Models
{
	public class Cart : BaseModel
	{
		public string UserId { get; set; }

		public virtual User User { get; set; }

		public ICollection<CartItem> CartItems { get; set; }
	}
}
