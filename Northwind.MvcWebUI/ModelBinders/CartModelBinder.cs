using Northwind.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Northwind.MvcWebUI.ModelBinders
{
    public class CartModelBinder:IModelBinder
    {
        //    public RedirectToRouteResult AddToCart(Cart cart,int productId)  misal cart modeline Sessiondaki cartı ata dicez .bind et dicez


        
        //   //olursa birisi senden controllerlardaki  metotun parametresinde  Cart nesnesini isterse ona Sessiondaki cartı vercek.CartModelBinder da bunu belirttik. 


        //global.asaxda da belirttik.
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var cart = (Cart)controllerContext.HttpContext.Session["cart"];


            if (cart==null)
            {
                cart = new Cart();
                controllerContext.HttpContext.Session["cart"] = cart;
            }




            return cart;
        }
    }
}