using Ninject;//ekledik
using Northwind.Bll.Concrete;
using Northwind.Dal.Concrete.EntityFramework;
using Northwind.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject.Extensions.Interception;
using Northwind.CrossCuttingConcerns.Logging;
namespace Northwind.MvcWebUI.Infrastructure
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {

        IKernel _ninjectKernel;

        public NinjectControllerFactory()
        {
            _ninjectKernel = new StandardKernel();
            //AddBllBindings(); //sistemi bll'e geçirmek için
            AddServiceBindings();//sistemi servise geçirdik


        }

        //Business Bindingleri
        private void AddBllBindings()
        {
            _ninjectKernel.Bind<IProductService>().To<ProductManager>().WithConstructorArgument("productDal", new EfProductDal());               //olurda birisi senden IProductService isterse ona ProductManager sınıfını ver diyoruz.yani controllerdaki constructorda  public ProductController(IProductService productService) IProductService istemişti.bizde ona Productmanager vermiş olduk
            _ninjectKernel.Bind<ICategoryService>().To<CategoryManager>().WithConstructorArgument("categoryDal", new EfCategoryDal());               //olurda birisi senden ICategoryService isterse ona CategoryManager sınıfını ver diyoruz.yani controllerdaki constructorda  public CategoryController(ICategoryService categoryService) ICategoryService istemişti.bizde ona Categorymanager vermiş olduk
            _ninjectKernel.Bind<IAuthenticationService>().To<AuthenticationManager>().WithConstructorArgument("authenticationDal", new EfAuthenticationDal());  //withconstruct -->    AuthenticationManager sınıfındaki constructor daki parametreye    EfAuthenticationDal verdiğimizi söylüyoruz      


            //manage nugettan Ninject.Extensions.Interception  kuruyoruz
            //_ninjectKernel.Intercept(p => (true)).With(new LoggingInterceptor());

        }


        //service Bindingleri 
        private void AddServiceBindings()
        {
            //olurda biri senden IProductService isterse 
            _ninjectKernel.Bind<IProductService>().ToConstant(WcfProxy<IProductService>.CreateChannel());
            _ninjectKernel.Bind<ICategoryService>().ToConstant(WcfProxy<ICategoryService>.CreateChannel());
            _ninjectKernel.Bind<IAuthenticationService>().ToConstant(WcfProxy<IAuthenticationService>.CreateChannel());



        }



        protected override IController GetControllerInstance(System.Web.Routing.RequestContext requestContext, Type controllerType)
        {
            return controllerType == null ? null : (Controller)_ninjectKernel.Get(controllerType);
        }



    }
}


//manage nugettan ninject kuruyoruz.

//global asax dosyasına NinjectControllerFactory i kullan dememiz lazım .ControllerBuilder.Current.SetControllerFactory(new NinjectControllerFactory()); ekledik


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



/*
 Hata:
 * An exception of type 'Ninject.ActivationException' occurred in Ninject.dll but was not handled in user code

Additional information: Error activating IProductDal

No matching bindings are available, and the type is not self-bindable.
 
 * 
 * çünkü productmanagerında productdala ihtiyacı var .
 * 
 * 
 * .WithConstructorArgument("productDal",new EfProductDal());      eklemesi yaptık
 * 
 * 
 * 
 * 
 
 */