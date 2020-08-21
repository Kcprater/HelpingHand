using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpingHand.Models.ProviderService
{
    public class ProviderServiceCreate
    {
        public int ProviderID { get; set; }
        [Required]
        [Display (Name = "ServiceType")]
        public string ServiceType { get; set; } //
        [Required]
        [Display(Name = "Years of Experience")]
        public int Experience { get; set; }
        [Required]
        [Display(Name = "Rate for Service")]
        public string Rate { get; set; }
    }
}