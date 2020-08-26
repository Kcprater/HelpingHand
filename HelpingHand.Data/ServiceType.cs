using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpingHand.Data
{
    public enum ServiceTypes { Home, Cleaning, Education, Music}
    public class ServiceType
    {
        [Key]
        public int ServiceTypeID { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        public string Subcategory { get; set; }
    }
}
