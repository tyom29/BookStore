using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Domain.Entities
{
    public class SheepingDetails
    {
        [Required(ErrorMessage ="Enter Your Name")]
        public string Name { set; get; }
        [Required(ErrorMessage = "Enter Line 1")]
        public string Line_1 { set; get; }
        public string Line_2 { set; get; }
        public string Line_3 { set; get; }
        [Required(ErrorMessage = "Enter City")]
        public string City { set; get; }
        public string State { set; get; }
        [Required(ErrorMessage = "Enter Country")]
        public string Country { set; get; }
        public string Zip { set; get; }
        public bool GiftWrap { set; get; }
    }
}
