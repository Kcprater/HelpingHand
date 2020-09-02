using HelpingHand.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Core.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpingHand.Models.Provider
{
    public class ProviderDetail
    {
        [Display(Name = "Provider ID")]
        public int ProviderID { get; set; }
        [Display(Name = "ID")]
        public Guid ID { get; set; }
        [Display(Name = "Provider Name")]
        public string Name { get; set; }
        [Display(Name = "Provider Email")]
        public string Email { get; set; }
        [Display(Name = "Provider Phone Number")]
        public string Phone { get; set; }
        [Display(Name = "City")]
        public string City { get; set; }
        [Display(Name = "State")]
        public string State { get; set; }
    }
}
