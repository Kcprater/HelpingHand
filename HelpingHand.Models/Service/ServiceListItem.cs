using HelpingHand.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpingHand.Models.Service
{
    public class ServiceListItem
    {
        [Display(Name = "Service ID")]
        public int ServiceID { get; set; }
        [Display(Name = "Provider ID")]
        public int ProviderID { get; set; }
        [Display(Name = "Category")]
        public string Category { get; set; }
        [Display(Name = "Subcategory")]
        public string Subcategory { get; set; }
        [Display(Name = "Years of Experience")]
        public int Experience { get; set; }
        [Display(Name = "Rate for Service")]
        public string Rate { get; set; }
    }
}
