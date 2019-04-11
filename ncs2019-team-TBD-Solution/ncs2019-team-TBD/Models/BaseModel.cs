using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ncs2019_team_TBD.Models
{
	public class BaseModel
	{
		public int Id {
			get;
			set;
		}

		public string Name {
			get;
			set;
		}

		public DateTime DateCreated {
			get;
			set;
		}
        /// <summary>
        /// 
        /// </summary>

		public DateTime DateUpdated {
			get;
			set;
		}

		public Guid UserCreated {
			get;
			set;
		}

		public Guid UserUpdated {
			get;
			set;
		}

	}
}
