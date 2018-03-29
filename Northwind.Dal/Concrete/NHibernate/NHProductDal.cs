using Northwind.Dal.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Dal.Concrete.NHibernate
{
    //Proje Nhibernate'e geçildiğinde burayı doldur.
    public class NHProductDal : IProductDal
    {
        public List<Entities.Product> GetAll()
        {
            throw new NotImplementedException();
        }

        public Entities.Product Get(int productId)
        {
            throw new NotImplementedException();
        }

        public void Add(Entities.Product product)
        {
            throw new NotImplementedException();
        }

        public void Delete(int productId)
        {
            throw new NotImplementedException();
        }

        public void Update(Entities.Product product)
        {
            throw new NotImplementedException();
        }
    }
}
