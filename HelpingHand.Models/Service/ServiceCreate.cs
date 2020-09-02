using HelpingHand.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpingHand.Models.Service
{
    public class ServiceCreate
    {
        public int ProviderID { get; set; }
        [Required]
        [Display (Name = "Category")]
        public string Category { get; set; }
        [Required]
        [Display(Name = "Subcategory")]
        public string Subcategory { get; set; }
        [Required]
        [Display(Name = "Years of Experience")]
        public int Experience { get; set; }
        [Required]
        [Display(Name = "Rate for Service")]
        public string Rate { get; set; }
    }
}