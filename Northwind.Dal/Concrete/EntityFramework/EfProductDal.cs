using Northwind.Dal.Abstract;
using Northwind.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Dal.Concrete.EntityFramework
{
    public class EfProductDal:IProductDal
    {
        public NorthwindContext _context = new NorthwindContext();
        public List<Entities.Product> GetAll()
        {
            return _context.Products.ToList();
        }

        public Entities.Product Get(int productId)
        {
            return _context.Products.FirstOrDefault(x => x.ProductID == productId);
        }

        public void Add(Entities.Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public void Delete(int productId)
        {
            _context.Products.Remove(_context.Products.FirstOrDefault(x => x.ProductID == productId));
            _context.SaveChanges();
        }

        public void Update(Entities.Product product)
        {
            Product productToUpdate = _context.Products.FirstOrDefault(x => x.ProductID == product.ProductID);
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryID = product.CategoryID;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;

            _context.SaveChanges();
        }
    }
}
