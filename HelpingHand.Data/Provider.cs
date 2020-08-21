using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpingHand.Data
{
    public class Provider
    {
        [Key]
        public int ProviderID { get; set; }
        [Required]
        public Guid ID { get; set; }
        [Required]
        [MinLength(4)]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [MaxLength(10), MinLength(7)]
        public string Phone { get; set; }
        [Required]
        [MaxLength(17), MinLength(3)]
        public string City { get; set; }
        [Required]
        [MaxLength(12), MinLength(4)]
        public string State { get; set; }
    }
}
