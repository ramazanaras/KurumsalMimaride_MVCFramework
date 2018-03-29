using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations; //dll olarak ekledik
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Entities
{
    public class ShippingDetails
    {

        [Required(ErrorMessage="İsim girilmesi zorunludur")]
        [Display(Name="Ad Soyad")]
        //[RegularExpression("a")]
        public string Name { get; set; }
        [Required()]
        [MinLength(10)]
        [MaxLength(50)]
        public string Address1 { get; set; }

        [MaxLength(50)]
        public string Address2 { get; set; }

        [MaxLength(50)]
        public string Address3 { get; set; }

        [Required()]
        public string City { get; set; }
        
        
        public string Country { get; set; }

        public bool IsGift { get; set; }


    }
}
