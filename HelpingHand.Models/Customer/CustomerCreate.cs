using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpingHand.Models.Customer
{
    public class CustomerCreate
    {
        [Required]
        [Display(Name = "Customer Name")]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "Customer Email")]
        public string Email { get; set; }
        [Required]
        [Display(Name = "City")]
        public string City { get; set; }
        [Required]
        [Display(Name = "State")]
        public string State { get; set; }
    }
}
