using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class Products : ModelBase
    {
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public decimal Price { get; set; }

        public Category Category { get; set; }

        // public virtual Category Category { get; set; }



    }
}
