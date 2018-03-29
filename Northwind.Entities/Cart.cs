using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Entities
{
    public class Cart
    {
        
        List<CartLine> _lines = new List<CartLine>();


        public void AddToCart(Product product, int quantity)
        {

            CartLine cartline = _lines.FirstOrDefault(c => c.Product.ProductID == product.ProductID); //sepette varmı


            if (cartline==null)
            {
                //sepete ekle
                _lines.Add(new CartLine { Product = product, Quantity = quantity });
            }
            else
            {
                cartline.Quantity += quantity;   //adet arttır

            }
        }



        public void RemoveFromCart(Product product)
        {
            _lines.RemoveAll(p => p.Product.ProductID == product.ProductID); //eşit olanları kaldır.birden fazla varsa siler.
        }


        public decimal Total //sepet toplam tutar
        {
            get
            {

                return _lines.Sum(c => c.Product.UnitPrice.Value * c.Quantity);
            }
        }


        //sepet sil
        public void Clear()
        {
            _lines.Clear();
        }

        public List<CartLine> Lines
        {
            get
            {
                return _lines;
            }
        } 


    }

    public class CartLine
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
