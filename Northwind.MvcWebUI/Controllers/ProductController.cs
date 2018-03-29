using Northwind.Bll.Concrete;
using Northwind.Dal.Concrete.EntityFramework;
using Northwind.Dal.Concrete.NHibernate;
using Northwind.Entities;
using Northwind.Interfaces;
using Northwind.MvcWebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Northwind.MvcWebUI.Controllers
{
    public class ProductController : Controller
    {
        //işkatmanına gittik.ama belki biz ilerde servis katmanını kullancaz. o zaman ne yapıcaz.Bunu çözmek için dependency injection yapıcaz.
        //ProductManager _productManager = new ProductManager(new EfProductDal());//kötü bir kod (bunun yerine Ninject yapıcaz.yani dependency injection uyguluyacaz.)
        //ProductManager _productManager = new ProductManager(new NHProductDal());


        //IProductService _productService=new ProductManager(new EfProductDal()); //aşağıdaki gibi constructor vasıtasıyla enjecte edicez



        //dependency enjection 
        private IProductService _productService;
        public ProductController(IProductService productService) //ProductManager veya Service sınıfı verebiliriz.artık bağımlılıkları azalttık.
        {
            _productService = productService;
        }



        //Sayfalama
        public int PageSize = 5;
        //http://localhost:3438/Product/Index?category=6
        //http://localhost:3438/Product/Index?category=7&page=1
        public ViewResult Index(int page = 1,int category=0)//Model Binding-->http://localhost:3438/Product/Index?page=2 query string yöntemiyle controllera veri gönderdik.
        {
            //Skip --> atlamak
            List<Product> products = _productService.GetAll().Where(p => p.CategoryID == category ||category==0).ToList();
            return View(new ProductViewModel
            {

                Products = products.Skip((page - 1) * PageSize).Take(5).ToList(),
                PagingInfo = new PagingInfo { ItemsPerPage=PageSize,TotalItems=products.Count,CurrentPage=page,CurrentCategory=category}



            });
        }



    }
}


//Hata:
//Bu nesne için parametresi olmayan oluşturucu tanımlanmamış.
/*
  public ProductController(IProductService productService) //ProductManager veya Service sınıfı verebiliriz.artık bağımlılıkları azalttık.
        {
            _productService = productService;
        }

 çünkü parametreye değer vermedik.Çünkü IProductService'in ne olduğunu bilmiyorum dedi. Ninject tekniğiyle constructorda bizden IProductservice istendiğinde git ProductManager ver. veya Productservice ver diyicez.böylece hatadan kurtulcaz ve bağımlılıkları azaltcaz.
 * Bunun için Infrastructure(altyapı) klasörünün içine NinjectControllerFactory sınıf yaptık.
 
 */