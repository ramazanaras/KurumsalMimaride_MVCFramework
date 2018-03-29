using Northwind.Entities;
using Northwind.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Northwind.MvcWebUI.Controllers
{
    public class CartController : Controller
    {

        IProductService _productService;
        public CartController(IProductService productService)//dependecy injection
        {
            _productService = productService;
        }

        public RedirectToRouteResult AddToCart(Cart cart,int productId)  //ModelBinderda cart nesnesine Sessiondaki değeri ata diye işlemler yaptık. 
        {

            Product product = _productService.Get(productId);

            //Cart cart = (Cart)Session["cart"];
            //if (cart == null)
            //{

            //    cart = new Cart();
            //    Session["cart"] = cart;


            //}

            cart.AddToCart(product, 1);


            return RedirectToAction("Index", cart);
        }


        //ModelBinderda cart nesnesine Sessiondaki değeri ata diye işlemler yaptık. 
        public ActionResult Index(Cart cart)
        {
            //var cart = (Cart)Session["cart"];
            return View(cart);
        }

        //ModelBinderda cart nesnesine Sessiondaki değeri ata diye işlemler yaptık. 
        public RedirectToRouteResult RemoveFromCart(Cart cart,int productId)
        {
            Product product = _productService.Get(productId);
            //Cart cart = (Cart)Session["cart"];


            //if (cart.Lines.Count == 0)
            //{

            //    ModelState.AddModelError("","Sepette zaten urun yok");


            //}
            //else
            //{
            cart.RemoveFromCart(product);
            //}


            return RedirectToAction("Index", cart);


        }

        [HttpGet]
        public ActionResult Checkout()
        {

            return View(new ShippingDetails());
        }


        [HttpPost]
        public ActionResult Checkout(ShippingDetails shippingDetails)
        {
            if (ModelState.IsValid)//model bilgileri doğru girilmişse
            {
                //Managerdan veritabanına kayıt sağlanacak

                return View("Completed");
            }
            else
            {
                return View(shippingDetails);
            }


        }

        //ModelBinderda cart nesnesine Sessiondaki değeri ata diye işlemler yaptık. 
        public PartialViewResult CartSummary(Cart cart)//sepet özeti
        {
            //Cart cart = (Cart)Session["cart"];

            //if (cart==null)
            //{
            //    cart = new Cart();
            //}

            return PartialView(cart);

        }










    }
}