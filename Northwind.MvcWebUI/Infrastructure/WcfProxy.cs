using Northwind.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel; //Dll'ide ekledik  (BasicHttpBinding sınıfı için)
using System.Web;

namespace Northwind.MvcWebUI.Infrastructure
{
    //Client tarafında enpoint oluşturmak için yaptık bu classı
    public static class WcfProxy<T>
    {


        //Generic halde yaptık
        public static T CreateChannel()
        {
            string address = string.Format("http://localhost:3427/{0}.svc?wsdl", typeof(T).Name.Substring(1));  //WCF ABC'sinin a'sı
            var binding = new BasicHttpBinding();   //WCF ABC'sinin b'sı

            var channel = new ChannelFactory<T>(binding, address);



            return channel.CreateChannel();


        }


        //public static IProductService CreateChannel()
        //{
        //    string address = "http://localhost:3427/ProductService.svc?wsdl";  //WCF ABC'sinin a'sı
        //    var binding = new BasicHttpBinding();   //WCF ABC'sinin b'sı

        //    var channel = new ChannelFactory<IProductService>(binding,address);



        //    return channel.CreateChannel();
        
        
        //}
    }
}

// http://localhost:3427/ProductService.svc