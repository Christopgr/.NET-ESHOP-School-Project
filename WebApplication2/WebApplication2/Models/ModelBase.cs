using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class ModelBase
    {
        /// <summary>
        /// 
        /// </summary>
        [Key]

        public int Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }
        public string Description { get; set; }
            
        public DateTime? DateUpdated { get; set; }   //nullable
        public Guid CreatedByID { get; set; }
        public Guid UpdatedById { get; set; }


    }
}
