using Northwind.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Northwind.Entities;
using Northwind.Bll.Concrete;
using Northwind.Dal.Concrete.EntityFramework;
namespace Northwind.WcfLibrary.Concrete
{
    public class ProductService : IProductService
    {

        //Kural:Soa standartlarında bir servisin constructoru olamaz

        //BLL katmanındaki sınıfı kullanıyoruz
        //Instance Provider ile ezilecek
        private ProductManager _productManager = new ProductManager(new EfProductDal());  //IProductDal 'dan implemente edilmiş bir sınıf vermeliyiz.Hangi teknolojiyle çalışacağımızı belirttik.Entity framework ile çalıştığımız için bunu verdik.
        public List<Product> GetAll()
        {
            return _productManager.GetAll();
        }

        public Product Get(int productId)
        {
            return _productManager.Get(productId);
        }

        public void Add(Product product)
        {
            _productManager.Add(product);
        }

        public void Delete(int productId)
        {
            _productManager.Delete(productId);
        }

        public void Update(Product product)
        {
            _productManager.Update(product);
        }
    }
}


/*
 servisleri yayına çıkarmak için aşağıdakileri WCFIISHost katmanına ekledik
 * 
 *  <!--ekledik-->
    <serviceHostingEnvironment aspNetCompatibilityEnabled="true" multipleSiteBindingsEnabled="true">
      <serviceActivations>
        <add service="Northwind.WcfLibrary.Concrete.ProductService" relativeAddress="ProductService.svc"/>
        <add service="Northwind.WcfLibrary.Concrete.CategoryService" relativeAddress="CategoryService.svc"/>
        <add service="Northwind.WcfLibrary.Concrete.AuthenticationService" relativeAddress="AuthenticationService.svc"/>
      </serviceActivations>
    </serviceHostingEnvironment>
 
 * 
 * 
 * 
 * 
 * 
 * http://localhost:3427/Product.svc
 * http://localhost:3427/Category.svc
 */