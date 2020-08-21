using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpingHand.Models.Provider
{
    public class ProviderCreate
    {
        [Required]
        [Display(Name = "Provider Name")]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "Provider Email")]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Provider Phone Number")]
        public string Phone { get; set; }
        [Required]
        [Display(Name = "City")]
        public string City { get; set; }
        [Required]
        [Display(Name = "State")]
        public string State { get; set; }
    }
}
