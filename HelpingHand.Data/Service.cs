using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpingHand.Data
{
    public enum Category { Home, Cleaning, Education, Music }

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
        public Category Category { get; set; }
        [Required]
        public int Experience { get; set; }
        [Required]
        public string Rate { get; set; }
    }
}
