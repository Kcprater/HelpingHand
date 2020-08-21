using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpingHand.Models.Customer
{
    public class CustomerDetail
    {
        [Display(Name = "Customer ID")]
        public int CustomerID { get; set; }
        [Display(Name = "ID")]
        public Guid ID { get; set; }
        [Display(Name = "Customer Name")]
        public string Name { get; set; }
        [Display(Name = "Customer Email")]
        public string Email { get; set; }
        [Display(Name = "City")]
        public string City { get; set; }
        [Display(Name = "State")]
        public string State { get; set; }
    }
}
