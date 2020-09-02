using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace HelpingHand.Data
{
    public class Service
    {
        [Key]
        public int ServiceID { get; set; }
        [Required]
        public Guid ID { get; set; }
        //[Required]
        public int ProviderID { get; set; }
        [ForeignKey(nameof(ProviderID))]
        public virtual Provider Provider { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        public string Subcategory { get; set; }
        [Required]
        public int Experience { get; set; }
        [Required]
        public string Rate { get; set; }
    }
}
