using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations; //dll'ide ekledik
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Northwind.Entities
{

    //Concrete:Somut sınıflar
    public class Product
    {

        [HiddenInput(DisplayValue=false)] //viewde gözükmesin diye yaptık
        public int ProductID { get; set; }

        [Required]
        public string ProductName { get; set; }
        [Required]
        public short? UnitsInStock { get; set; }

        [Required]
        public decimal? UnitPrice { get; set; }

        [Required]
        public int CategoryID { get; set; }




        //Additional information: The 'UnitsInStock' property on 'Product' could not be set to a 'System.Int16' value. You must set this property to a non-null value of type 'System.Int32'.
        //Çözümü nullable yap decimal? veya int? gibi
    }
}


