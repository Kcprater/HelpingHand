using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpingHand.Data
{
    public class ServiceType
    {
        [Key]
        public int ServiceTypeID { get; set; }
        //[Required]
        //public Category Category { get; set; }
        [Required]
        public string Subcategory { get; set; }
    }
}
