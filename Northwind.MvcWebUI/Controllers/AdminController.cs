using Northwind.Entities;
using Northwind.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Northwind.MvcWebUI.Controllers
{
    public class AdminController : Controller
    {

        IProductService _productService;
        public AdminController(IProductService productService)//dependency injection
        {
            _productService = productService;
        }

        public ActionResult Index()
        {
            return View(_productService.GetAll());
        }


        [Authorize]
        public ActionResult CreateNew()
        {

            return View(new Product());
        }


        [HttpPost]
        [Authorize]//Giriş yapılmamışsa Account/Login e yönlendir.
        /*HTTP Error 401.0 - Unauthorized
Bu dizini veya sayfayı görüntüleme izniniz yok.
         
         *  Webconfige ekledik. Giriş yapılmamışsa Account/Login e yönlendir.
 *   <authentication mode="Forms" >
      <forms loginUrl="~/Account/Login" timeout="2800" />
    </authentication>
 
         * 
         * 
         */

        public ActionResult CreateNew(Product product)
        {
            if (ModelState.IsValid) //model doğru gelmişse
            {
                _productService.Add(product);
                return RedirectToAction("Index");
            }

            //model yanlış gelmişse
            return View(product);
        }
        public ActionResult Edit(int productId)
        {



            return View(_productService.Get(productId));
        }


        [HttpPost]
        public ActionResult Edit(Product product)
        {

            if (ModelState.IsValid) //model doğru gelmişse
            {
                _productService.Update(product);
                return RedirectToAction("Index");
            }

            //model yanlış gelmişse
            return View(product);
        }

    }
}