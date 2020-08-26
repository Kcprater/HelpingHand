using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpingHand.Data
{
    public class Service
    {
        [Key]
        public int ServiceID { get; set; }
        [Required]
        [ForeignKey(nameof(Provider))]
        public int ProviderID { get; set; }
        public Provider Provider { get; set; }
        [Required]
        public int Experience { get; set; }
        [Required]
        public string Rate { get; set; }
    }
}
