using Northwind.Interfaces;//referanslara ekledik
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Northwind.Entities;//referanslara ekledik
using Northwind.Dal.Concrete.EntityFramework;
using Northwind.Dal.Abstract;//referanslara ekledik
namespace Northwind.Bll.Concrete
{
    public class ProductManager : IProductService
    {
     


        //EfProductDal productDal = new EfProductDal(); bunu yazarsak yanlış olur çünkü ilerde Nhiberante geçersek hep değiştirmek zorunda  kalırız.bu yüzden aşağıda constructor injection yaptık.Nhibernate veya entity framework farketmez istediğimize constructorda veririz.yani bu interface'den implemente olan sınıfları verebiliriz.EfProductDal veya NHProductDal

        private IProductDal _productDal;

        public ProductManager(IProductDal productDal)//Dependency ınjection(İstersek EfProductdal istersek NHProduct dal verebiliriz.Veri erişim katmanından bağımsızlaştırdı )
        {
            _productDal = productDal;
        }
        public List<Product> GetAll()
        {
            //Valdiation
            //Security
            //exception handling


            return _productDal.GetAll();



            //return productDal.GetAll(); yanlış işlem
        }

        public Product Get(int productId)
        {
            return _productDal.Get(productId);
        }

        public void Add(Product product)
        {
            _productDal.Add(product);
        }

        public void Delete(int productId)
        {
            _productDal.Delete(productId);
      
        }

        public void Update(Product product)
        {
            _productDal.Update(product);
        }


      
    }
}
