using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class Category : ModelBase
    {
        public ICollection<Products> Products { get; set; }

    }
}
