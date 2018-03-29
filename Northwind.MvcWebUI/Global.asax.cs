using Northwind.Entities;
using Northwind.MvcWebUI.Infrastructure;
using Northwind.MvcWebUI.ModelBinders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Northwind.MvcWebUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            //dependency injectionı ekledik.
            ControllerBuilder.Current.SetControllerFactory(new NinjectControllerFactory());


            //olursa birisi senden controllerlardaki  metotun parametresinde  Cart nesnesini isterse ona Sessiondaki cartı vercek.CartModelBinder da bunu belirttik. 
            System.Web.Mvc.ModelBinders.Binders.Add(typeof(Cart),new CartModelBinder());

         

        }
    }
}
