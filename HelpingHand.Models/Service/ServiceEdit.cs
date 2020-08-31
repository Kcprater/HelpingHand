using HelpingHand.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpingHand.Models.Service
{
    public class ServiceEdit
    {
        [Required]
        [Display(Name = "Service ID")]
        public int ServiceID { get; set; }
        [Required]
        [Display(Name = "Provider ID")]
        public int ProviderID { get; set; }
        [Required]
        [Display(Name = "ServiceType")]
        public Category Category { get; set; } //
        [Required]
        [Display(Name = "Years of Experience")]
        public int Experience { get; set; }
        [Required]
        [Display(Name = "Rate for Service")]
        public string Rate { get; set; }
    }
}
