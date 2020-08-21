using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpingHand.Models.ProviderService
{
    public class ProviderServiceDetail
    {
        [Display(Name = "Service ID")]
        public int ServiceID { get; set; }
        [Display(Name = "Provider ID")]
        public int ProviderID { get; set; }
        [Display(Name = "ServiceType")]
        public string ServiceType { get; set; } //
        [Display(Name = "Years of Experience")]
        public int Experience { get; set; }
        [Display(Name = "Rate for Service")]
        public string Rate { get; set; }
    }
}
